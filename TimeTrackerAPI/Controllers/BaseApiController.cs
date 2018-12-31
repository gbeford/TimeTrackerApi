using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace TimeTrackerAPI.Controllers
{

public class BaseApiController : Controller
{
protected IActionResult HandleException(Exception ex, string message)
{
            IActionResult ret;

            // Create new exception with generic message
            ret = StatusCode(
                StatusCodes.Status500InternalServerError, new Exception());
            return ret;

        }

}



}