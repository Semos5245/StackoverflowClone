using Microsoft.AspNetCore.Mvc;
using Stackoverflow.Website.Services;

namespace Stackoverflow.Website.Controllers
{
    public abstract class BaseController : Controller
    {
        protected readonly IUserService _userService;
        public BaseController(IUserService userService)
            => _userService = userService;

        protected IActionResult NotFoundView(string message = null)
        {
            ViewData["Message"] = message;
            return View("Views\\Shared\\NotFound.cshtml");
        }

        protected IActionResult BadRequestView(string message = null)
        {
            ViewData["Message"] = message;
            return View("Views\\Shared\\Error.cshtml");
        }

        protected IActionResult AccessDeniedView(string message = null)
        {
            ViewData["Message"] = message;
            return View("Views\\Shared\\AccessDenied.cshtml");
        }
    }
}
