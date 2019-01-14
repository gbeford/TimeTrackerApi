using System.Collections.Generic;
using TimeTrackerAPI.Models;

namespace TimeTrackerAPI.Security
{
    public interface ISecurityManagerService
    {
        AppUserAuth ValidateUser(AppUser user);
        List<AppUserClaim> GetUserClaims(AppUser authUser);
        AppUserAuth BuildUserAuthObject(AppUser authUser);


    }
}