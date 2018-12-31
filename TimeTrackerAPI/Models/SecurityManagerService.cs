using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using TimeTrackerAPI.Models;


namespace TimeTrackerAPI.Security
{
    public class SecurityManagerService : ISecurityManagerService
    {
        private readonly TimeTrackerDbContext db;
        private readonly JwtSettings _settings;
        public SecurityManagerService(TimeTrackerDbContext context, JwtSettings jwt)
        {
            db = context;
            _settings = jwt;
        }
        public AppUserAuth ValidateUser(AppUser user)
        {
            AppUserAuth ret = new AppUserAuth();
            AppUser authUser = null;


            // Attempt to validate user
            authUser = db.LoginUsers.Where(
                u => u.UserName.ToLower() == user.UserName.ToLower()
                && u.Password == user.Password).FirstOrDefault();

            if (authUser != null)
            {
                // Build User Security Object
                ret = BuildUserAuthObject(authUser);
            }
            return ret;
        }

        public List<AppUserClaim> GetUserTypes(AppUser authUser)
        {
            List<AppUserClaim> list = new List<AppUserClaim>();
            try
            {

                list = db.ClaimTypes.Where(
                     u => u.UserId == authUser.UserId).ToList();

            }
            catch (Exception ex)
            {
                throw new Exception(
                    "Exception trying to retrieve user type.", ex);
            }
            return list;
        }

        protected string BuildJwtToken(AppUserAuth authUser)
        {
            SymmetricSecurityKey key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_settings.Key));

            //Create standard JWT claims
            List<Claim> jwtClaims = new List<Claim>();
            jwtClaims.Add(new Claim(JwtRegisteredClaimNames.Sub, authUser.UserName));
            jwtClaims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));

            // add custom claim
            jwtClaims.Add(new Claim("isAuthenticated", authUser.IsAuthenticated.ToString().ToLower()));
            jwtClaims.Add(new Claim("CanAccess_Admin", authUser.CanAccess_Admin.ToString().ToLower()));
            jwtClaims.Add(new Claim("CanAccess_Student", authUser.CanAccess_Student.ToString().ToLower()));

            // Create the JwtSecurityToken object
            var token = new JwtSecurityToken(
                issuer: _settings.Issuer,
                audience: _settings.Audience,
                claims: jwtClaims,
                notBefore: DateTime.UtcNow,
                expires: DateTime.UtcNow.AddMinutes(_settings.MinutesToExpiration),
                signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
            );
            //Create a string representation of the Jwt token
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public AppUserAuth BuildUserAuthObject(AppUser authUser)
        {
            AppUserAuth ret = new AppUserAuth();
            List<AppUserClaim> roleTypes = new List<AppUserClaim>();

            // Set User Properties
            ret.UserName = authUser.UserName;
            ret.IsAuthenticated = true;
            ret.BearerToken = new Guid().ToString();

            // Get all types for this user
            roleTypes = GetUserTypes(authUser);

            // Loop through all types and
            // set properties of user object
            foreach (AppUserClaim type in roleTypes)
            {
                try
                {
                    // ToDO check data tyep of typeValue
                    typeof(AppUserAuth).GetProperty(type.ClaimType)
                    .SetValue(ret, Convert.ToBoolean(type.ClaimValue), null);
                }
                catch
                {

                }
            }
            ret.BearerToken = BuildJwtToken(ret);

            return ret;

        }

    }

}

