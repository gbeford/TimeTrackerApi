using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TimeTrackerAPI.Security;
using TimeTrackerAPI.Models;

namespace TimeTrackerAPI.Controllers
{
    [Route("api/[controller]")]
    public class SecurityController : BaseApiController
    {
        private readonly ISecurityManagerService svcMgr;
        public SecurityController(ISecurityManagerService svc)
        {
            svcMgr = svc;
        }

        [HttpPost("Login_User")]
        public IActionResult Login([FromBody]AppUser user)
        {
            IActionResult ret = null;
            AppUserAuth auth = new AppUserAuth();

            auth = svcMgr.ValidateUser(user);
            if (auth.IsAuthenticated)
            {
                ret = StatusCode(StatusCodes.Status200OK, auth);
            }
            else
            {
                ret = StatusCode(StatusCodes.Status404NotFound, " Invalid User Name / Password.");
            }
            return ret;
        }
    }



}
