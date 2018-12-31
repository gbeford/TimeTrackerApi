using System;
using System.Collections.Generic;
using System.Linq;
using TimeTrackerAPI.Models;


namespace TimeTrackerAPI.Security
{
    public class SecurityManager
    {
        private readonly TimeTrackerDbContext db;
        public SecurityManager(TimeTrackerDbContext context)
        {
            db = context;
        }
        public AppUserAuth ValidateUser(AppUser user)
        {
            AppUserAuth ret = new AppUserAuth();
            AppUser authUser = null;

            using (db)
            {
                // Attempt to validate user
                authUser = db.LoginUsers.Where(
                    u => u.UserName.ToLower() == user.UserName.ToLower()
                    && u.Password == user.Password).FirstOrDefault();

            }

            if (authUser != null)
            {
                // Build User Security Object
                ret = BuildUserAuthObject(authUser);
            }
            return ret;
        }

        public List<AppUserType> GetUserTypes(AppUser authUser)
        {
            List<AppUserType> list = new List<AppUserType>();
            try
            {
                using (db)
                {
                    list = db.RoleTypes.Where(
                         u => u.UserId == authUser.UserId).ToList();
                }
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
            List<AppUserType> roleTypes = new List<AppUserType>();

            // Set User Properties
            ret.UserName = authUser.UserName;
            ret.IsAuthenticated = true;
            ret.BearerToken = new Guid().ToString();

            // Get all types for this user
            roleTypes = GetUserTypes(authUser);

            // Loop through all types and
            // set properties of user object
            foreach (AppUserType type in roleTypes)
            {
                try
                {
                    typeof(AppUserAuth).GetProperty(type.RoleType)
                    .SetValue(ret, Convert.ToBoolean(type.RoleTypeValue), null);
                }
                catch
                {

                }
            }
            return ret;

        }

    }

}

