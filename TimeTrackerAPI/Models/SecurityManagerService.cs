using System;
using System.Collections.Generic;
using System.Linq;
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
            return ret;

        }

    }

}

