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

        public List<AppUserClaim> GetUserClaims(AppUser authUser)
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
            List<Claim> jwtClaims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, authUser.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),

                // add custom claim
                new Claim("isAuthenticated", authUser.IsAuthenticated.ToString().ToLower())
            };

            // Add custom claims from the Claims array
            foreach (var claim in authUser.Claims)
            {
                jwtClaims.Add(new Claim(claim.ClaimType, claim.ClaimValue));
            }

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
            AppUserAuth ret = new AppUserAuth
            {

                // Set User Properties
                UserName = authUser.UserName,
                IsAuthenticated = true,
                BearerToken = new Guid().ToString(),

                // Get all claims for this user
                Claims = GetUserClaims(authUser)
            };
            ret.BearerToken = BuildJwtToken(ret);

            return ret;

        }

    }

}

