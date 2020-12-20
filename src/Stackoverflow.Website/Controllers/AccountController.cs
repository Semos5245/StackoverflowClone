using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Stackoverflow.Website.BusinessModels;
using Stackoverflow.Website.DataAccess;
using Stackoverflow.Website.Infrastructure;
using Stackoverflow.Website.Services;
using Stackoverflow.Website.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Stackoverflow.Website.Controllers
{
    [Authorize]
    public class AccountController : BaseController
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly ApplicationDbContext _context;
        public AccountController(
            SignInManager<AppUser> signInManager,
            UserManager<AppUser> userManager,
            ApplicationDbContext context,
            IUserService userService) : base(userService)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _context = context;
        }

        #region Actions

        [HttpGet("[controller]/[action]")]
        [Authorize(Policy = Policies.AdminPolicy)]
        public async Task<IActionResult> Users()
        {
            var users = new List<UserViewModel>();

            foreach (var user in await _context.Users.ToListAsync())
            {
                users.Add(new UserViewModel
                {
                    Id = user.Id,
                    DisplayName = user.DisplayName,
                    Email = user.Email,
                    IsBlocked = user.IsBlocked,
                    Role = (await _userManager.GetRolesAsync(user))
                        .FirstOrDefault() ?? "Regular User"
                });
            }

            return View(users);
        }

        [HttpGet("[controller]/[action]")]
        [AllowAnonymous]
        public IActionResult Create()
            => View(new CreateUserViewModel());

        [HttpPost("[controller]/[action]")]
        [AllowAnonymous]
        //[Authorize(Policy = Policies.AdminPolicy)]
        public async Task<IActionResult> Create(CreateUserViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var existingUser = await _userManager.FindByEmailAsync(model.Email);

            if (existingUser != null)
            {
                ModelState.AddModelError("", "Email is taken.");
                return View(model);
            }

            existingUser = await _context.Users
                .FirstOrDefaultAsync(u => u.DisplayName.Equals(model.DisplayName.Trim()));

            if (existingUser != null)
            {
                ModelState.AddModelError("", "Display name is taken.");
                return View(model);
            }

            var user = new AppUser
            {
                DisplayName = model.DisplayName.Trim(),
                Email = model.Email,
                UserName = model.Email
            };

            await _userManager.CreateAsync(user, model.Password);
            await _userManager.AddToRoleAsync(user, Roles.Admin);

            return RedirectToAction(nameof(Users));
        }

        [AllowAnonymous]
        [HttpGet("[controller]/[action]")]
        public IActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [AllowAnonymous]
        [HttpPost("[controller]/[action]")]
        public async Task<IActionResult> Login(LoginViewModel model, string returnUrl = null)
        {
            if (!ModelState.IsValid) return View(model);

            var user = await _userManager.FindByEmailAsync(model.Email);

            if (user == null || !(await _signInManager.CheckPasswordSignInAsync(user, model.Password, false)).Succeeded)
            {
                ModelState.AddModelError("", "Invalid login attempt.");
                return View(model);
            }

            if (user.IsBlocked)
            {
                ModelState.AddModelError("", "You're blocked and can't login.");
                return View(model);
            }

            await _signInManager.SignInAsync(user, model.RememberMe);

            if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                return Redirect(returnUrl);

            return RedirectToAction("Index", "Home");
        }

        [AllowAnonymous]
        [HttpGet("[controller]/[action]")]
        public IActionResult SignUp() => View();

        [AllowAnonymous]
        [HttpPost("[controller]/[action]")]
        public async Task<IActionResult> SignUp(SignupViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var existingUser = await _userManager.FindByEmailAsync(model.Email);

            if (existingUser != null)
            {
                ModelState.AddModelError("", $"Email {model.Email} is already taken.");
                return View(model);
            }

            existingUser = await _context.Users
                .FirstOrDefaultAsync(u => u.DisplayName.Equals(model.DisplayName));

            if (existingUser != null)
            {
                ModelState.AddModelError("", "Display name already taken.");
                return View(model);
            }

            var newUser = new AppUser
            {
                Email = model.Email,
                UserName = model.Email,
                DisplayName = model.DisplayName.Trim()
            };

            await _userManager.CreateAsync(newUser, model.Password);

            return RedirectToAction(nameof(Login));
        }

        [HttpGet("[controller]/[action]")]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        [Authorize(Policy = Policies.AdminPolicy)]
        [HttpGet("[controller]/{userId}/[action]")]
        public async Task<IActionResult> Block(string userId)
        {
            userId = string.IsNullOrEmpty(userId) ? string.Empty : userId;

            var user = await _userManager.FindByIdAsync(userId);

            if (user is null)
                return NotFoundView();

            var role = (await _userManager.GetRolesAsync(user)).FirstOrDefault();

            if (role != null && role == Roles.Admin)
                return BadRequestView("Can't block an admin user.");

            if (user.IsBlocked)
                return BadRequestView("User is already blocked.");

            user.IsBlocked = true;
            await _userManager.UpdateAsync(user);

            return RedirectToAction(nameof(Users));
        }

        [Authorize(Policy = Policies.AdminPolicy)]
        [HttpGet("[controller]/{userId}/[action]")]
        public async Task<IActionResult> UnBlock(string userId)
        {
            userId = string.IsNullOrEmpty(userId) ? string.Empty : userId;

            var user = await _userManager.FindByIdAsync(userId);

            if (user is null)
                return NotFoundView();

            var role = (await _userManager.GetRolesAsync(user)).FirstOrDefault();

            if (role != null && role == Roles.Admin)
                return BadRequestView("Can't unblock an admin user.");

            if (!user.IsBlocked)
                return BadRequestView("User is not blocked.");

            user.IsBlocked = false;

            await _userManager.UpdateAsync(user);

            return RedirectToAction(nameof(Users));
        }

        #endregion
    }
}
