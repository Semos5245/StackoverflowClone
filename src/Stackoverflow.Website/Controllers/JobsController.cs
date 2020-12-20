using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Stackoverflow.Website.BusinessModels;
using Stackoverflow.Website.DataAccess;
using Stackoverflow.Website.Extensions;
using Stackoverflow.Website.Infrastructure;
using Stackoverflow.Website.Services;
using Stackoverflow.Website.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Stackoverflow.Website.Controllers
{
    //[Authorize]
    public class JobsController : BaseController
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly IWebHostEnvironment _webHost;
        public JobsController(
            ApplicationDbContext context,
            UserManager<AppUser> userManager,
            IWebHostEnvironment webHost,
            IUserService userService) : base(userService)
        {
            _context = context;
            _userManager = userManager;
            _webHost = webHost;
        }

        #region Actions

        [HttpGet("[controller]")]
        [AllowAnonymous]
        public async Task<IActionResult> Index(string query = null, bool mine = false)
        {
            ViewBag.Query = query;
            ViewBag.Mine = mine;
            var jobs = _context.Jobs.AsQueryable();
            if (!string.IsNullOrEmpty(query))
                jobs = jobs.Where(j => j.Title.Contains(query));

            var companyId = string.Empty;
            if (mine && (User?.IsInRole(Roles.CompanyOwner) ?? false))
            {
                companyId = (await _context.Companies.SingleAsync(c => c.UserId == _userService.LoggedInUserId)).Id;
                jobs = jobs.Where(j => j.CompanyId.Equals(companyId));
            }



            var jobsDetails = jobs.OrderByDescending(j => j.Views)
                .Select(j => new JobDetailsViewModel
                {
                    Id = j.Id,
                    CompanyLogoFileName = j.Company.LogoFileName,
                    Title = j.Title,
                    CompanyName = j.Company.Name,
                    CreatedFromUtc = j.CreatedDateUtc,
                    TechnologiesNeeded = j.TechnologiesNeeded,
                    CanModifyJob = j.CompanyId == companyId
                });
            return View(jobsDetails);
        }

        [AllowAnonymous]
        [HttpGet("[controller]/{id}/[action]")]
        public async Task<IActionResult> Details(string id)
        {
            var job = await _context.Jobs.FindAsync(id);

            if (job is null)
                return NotFoundView();
            var canModifyJob = false;

            if (User?.Identity?.Name != null)
            {
                canModifyJob = job.Company.UserId.Equals(_userService.LoggedInUserId);
            }

            job.Views += 1;
            await _context.SaveChangesAsync();

            return View(new JobDetailsViewModel
            {
                Id = job.Id,
                CreatedFromUtc = job.CreatedDateUtc,
                Title = job.Title,
                CompanyName = job.Company.Name,
                CompanyLogoFileName = job.Company.LogoFileName,
                CompanyLocation = job.Company.OfficeLocation,
                Description = job.Description,
                ExperienceLevel = job.ExperienceLevel.ToDisplayString(),
                IsRemote = job.IsRemote,
                MaxAnnualSalary = job.MaxAnnualSalary,
                MinAnnualSalary = job.MinAnnualSalary,
                Role = job.Role,
                Type = job.Type.ToDisplayString(),
                TechnologiesNeeded = job.TechnologiesNeeded,
                Industry = job.Company.Industry,
                CompanySize = job.Company.Size,
                CanModifyJob = canModifyJob
            });
        }

        [HttpGet("[controller]/[action]")]
        [Authorize(Policy = Policies.CompanyOwnerPolicy)]
        public IActionResult Create()
        {
            return View(new CreateJobViewModel());
        }

        [HttpPost("[controller]/[action]")]
        [Authorize(Policy = Policies.CompanyOwnerPolicy)]
        public async Task<IActionResult> Create(CreateJobViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var company = await _context.Companies
                .SingleOrDefaultAsync(c => c.UserId.Equals(_userService.LoggedInUserId));

            var job = new Job
            {
                Title = model.Title.Trim(),
                Description = model.Description.Trim(),
                MinAnnualSalary = model.MinAnnualSalary,
                MaxAnnualSalary = model.MaxAnnualSalary,
                Role = model.Role.Trim(),
                TechnologiesNeeded = model.TechnologiesNeeded,
                IsRemote = model.IsRemote,
                Type = model.Type.ToEnum<JobType>(),
                ExperienceLevel = model.ExperienceLevel.ToEnum<ExperienceLevel>(),
                CompanyId = company.Id
            };

            await _context.Jobs.AddAsync(job);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Details), new { id = job.Id });
        }

        [HttpGet("[controller]/[action]")]
        [Authorize(Policy = Policies.CompanyOwnerPolicy)]
        public async Task<IActionResult> Edit(string id)
        {
            var job = await _context.Jobs.FindAsync(id);

            if (job is null)
                return NotFoundView();
            if (!job.Company.UserId.Equals(_userService.LoggedInUserId))
                return AccessDeniedView();

            return View(new EditJobViewModel
            {
                Id = job.Id,
                Title = job.Title,
                Description = job.Description,
                ExperienceLevel = job.ExperienceLevelId,
                IsRemote = job.IsRemote,
                MaxAnnualSalary = job.MaxAnnualSalary,
                MinAnnualSalary = job.MinAnnualSalary,
                Role = job.Role,
                Type = job.TypeId,
                TechnologiesNeeded = job.TechnologiesNeeded
            });
        }

        [HttpPost("[controller]/[action]")]
        [Authorize(Policy = Policies.CompanyOwnerPolicy)]
        public async Task<IActionResult> Edit(EditJobViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var job = await _context.Jobs.FindAsync(model.Id);

            if (job is null)
                return NotFoundView();

            if (!job.Company.UserId.Equals(_userService.LoggedInUserId))
                return AccessDeniedView();

            job.EditedDateUtc = DateTime.UtcNow;
            job.Title = model.Title.Trim();
            job.Description = model.Description.Trim();
            job.MinAnnualSalary = model.MinAnnualSalary;
            job.MaxAnnualSalary = model.MaxAnnualSalary;
            job.TechnologiesNeeded = model.TechnologiesNeeded;
            job.Role = model.Role;
            job.IsRemote = model.IsRemote;
            job.ExperienceLevel = model.ExperienceLevel.ToEnum<ExperienceLevel>();
            job.Type = model.Type.ToEnum<JobType>();


            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Details), new { id = job.Id });
        }

        [HttpPost("[controller]/{id}/[action]")]
        [Authorize(Policy = Policies.CompanyOwnerPolicy)]
        public async Task<IActionResult> Delete(string id)
        {
            var job = await _context.Jobs.FindAsync(id);

            if (job is null)
                return NotFoundView();
            if (!_userService.LoggedInUserId.Equals(job.Company.UserId))
                return AccessDeniedView();

            _context.Jobs.Remove(job);
            await _context.SaveChangesAsync();
            
            return RedirectToAction(nameof(Index));
        }

        [AllowAnonymous]
        [HttpGet("[controller]/[action]")]
        public async Task<IActionResult> Companies(string query = null)
        {
            var companies = _context.Companies.AsQueryable();
            if (!string.IsNullOrEmpty(query))
                companies = companies.Where(c => c.Name.Contains(query));

            var companiesDetails = await companies.OrderByDescending(c => c.Views)
                .Select(c => new CompanyDetailViewModel
                {
                    Id = c.Id,
                    Name = c.Name,
                    ShortQuote = c.ShortQuote,
                    LongDescription = c.LongDescription,
                    OfficeLocation = c.OfficeLocation,
                    WebsiteUrl = c.WebsiteUrl,
                    TechStack = c.TechStack,
                    LogoFileName = c.LogoFileName,
                    Size = c.Size,
                    Founded = c.Founded,
                    Industry = c.Industry,
                    OpenedJobs = c.Jobs.Count,
                    CanModifyCompany = c.UserId == _userService.LoggedInUserId
                }).ToListAsync();

            return View(companiesDetails);
        }

        [Authorize(Policy = Policies.CompanyOwnerPolicy)]
        [HttpGet("[controller]/companies/[action]")]
        public async Task<IActionResult> MyCompany()
        {
            var company = await _context.Companies.SingleAsync
                (c => c.UserId.Equals(_userService.LoggedInUserId));

            return RedirectToAction(nameof(CompanyDetails), new { name = company.Name });
        }

        [AllowAnonymous]
        [HttpGet("[controller]/companies/{name}/details")]
        public async Task<IActionResult> CompanyDetails(string name)
        {
            if (string.IsNullOrEmpty(name)) return BadRequestView();

            var company = await _context.Companies
                .SingleOrDefaultAsync(c => c.Name.Equals(name));

            if (company is null) return NotFoundView();

            var canModifyJobs = false;

            if (User?.Identity?.Name != null)
            {
                canModifyJobs = company.UserId.Equals(_userService.LoggedInUserId);
            }

            company.Views += 1;
            
            var companyDetail = new CompanyDetailViewModel
            {
                Id = company.Id,
                Name = company.Name,
                ShortQuote = company.ShortQuote,
                LongDescription = company.LongDescription,
                OfficeLocation = company.OfficeLocation,
                TechStack = company.TechStack,
                WebsiteUrl = company.WebsiteUrl,
                Size = company.Size,
                Founded = company.Founded,
                LogoFileName = company.LogoFileName,
                Industry = company.Industry,
                CanModifyCompany
                    = _userService.LoggedInUserId.Equals(company.UserId),
                JobOpenings = company.Jobs.Select(j => new JobDetailsViewModel
                {
                    Id = j.Id,
                    Title = j.Title,
                    CompanyLogoFileName = company.LogoFileName,
                    CompanyName = company.Name,
                    CreatedFromUtc = j.CreatedDateUtc,
                    IsRemote = j.IsRemote,
                    MaxAnnualSalary = j.MaxAnnualSalary,
                    MinAnnualSalary = j.MinAnnualSalary,
                    TechnologiesNeeded = j.TechnologiesNeeded,
                    CanModifyJob = canModifyJobs
                })
            };

            await _context.SaveChangesAsync();

            return View(companyDetail);
        }

        [HttpGet("[controller]/companies/create")]
        [Authorize(Policy = Policies.AdminPolicy)]
        public async Task<IActionResult> CreateCompany(string userId)
        {
            var user = await _context.Users.FindAsync(userId);

            if (user is null)
                return NotFoundView("User does not exist.");

            return View(new CreateCompanyViewModel
            {
                UserId = userId,
                UserName = user.DisplayName
            });
        }

        [HttpPost("[controller]/companies/create")]
        [Authorize(Policy = Policies.AdminPolicy)]
        public async Task<IActionResult> CreateCompany(CreateCompanyViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.LogoFile != null && !model.LogoFile.IsValid(out var error))
            {
                ModelState.AddModelError("", error);
                return View(model);
            }

            var user = await _context.Users.FindAsync(model.UserId);

            if (user is null)
            {
                ModelState.AddModelError("", "User does not exist");
                return View(model);
            }

            var existingCompany = await _context.Companies
                .SingleOrDefaultAsync(c => c.UserId.Equals(user.Id));

            if (existingCompany != null)
            {
                ModelState.AddModelError("", "User is already connected to a company");
                return View(model);
            }

            existingCompany = await _context.Companies
                .FirstOrDefaultAsync(c => c.Name.Equals(model.Name.Trim()));

            if (existingCompany != null)
            {
                ModelState.AddModelError("", "There exists a company with the same name");
                return View(model);
            }

            var logoFileName = "default-logo.jpeg";

            if (model.LogoFile != null)
            {
                logoFileName = $"{Guid.NewGuid()}.jpeg";
                using var stream = new FileStream(Path.Combine(_webHost.WebRootPath, "images", logoFileName), FileMode.Create, FileAccess.Write);
                await model.LogoFile.CopyToAsync(stream);
            }

            var newCompany = new Company
            {
                Name = model.Name.Trim(),
                ShortQuote = model.ShortQuote.Trim(),
                LongDescription = model.LongDescription.Trim(),
                OfficeLocation = model.OfficeLocation.Trim(),
                TechStack = model.TechStack.Trim(),
                Founded = model.Founded.ToUniversalTime(),
                WebsiteUrl = model.WebsiteUrl.Trim(),
                LogoFileName = logoFileName,
                Size = model.Size,
                Industry = model.Industry,
                UserId = model.UserId
            };

            await _context.Companies.AddAsync(newCompany);
            await _context.SaveChangesAsync();

            await _userManager.AddToRoleAsync(user, Roles.CompanyOwner);

            return RedirectToAction(nameof(CompanyDetails), new { name = newCompany.Name });
        }

        [Authorize(Policy = Policies.CompanyOwnerPolicy)]
        [HttpGet("[controller]/companies/edit")]
        public async Task<IActionResult> EditCompany()
        {
            var company = await _context.Companies.SingleAsync
                (c => c.UserId == _userService.LoggedInUserId);

            if (company is null)
                return NotFoundView("Company does not exist.");

            if (!company.UserId.Equals(User.FindFirst(ClaimTypes.NameIdentifier).Value))
                return AccessDeniedView();

            return View(new EditCompanyViewModel
            {
                Name = company.Name,
                Founded = company.Founded,
                Industry = company.Industry,
                LongDescription = company.LongDescription,
                OfficeLocation = company.OfficeLocation,
                ShortQuote = company.ShortQuote,
                Size = company.Size,
                TechStack = company.TechStack,
                WebsiteUrl = company.WebsiteUrl
            });
        }

        [HttpPost("[controller]/companies/edit")]
        [Authorize(Policy = Policies.CompanyOwnerPolicy)]
        public async Task<IActionResult> EditCompany(EditCompanyViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var company = await _context.Companies
                .SingleOrDefaultAsync(c => c.UserId.Equals(_userService.LoggedInUserId));

            //if (!company.UserId.Equals(loggedInUserId))
            //    return AccessDeniedView();

            company.EditedDateUtc = DateTime.UtcNow;
            company.Name = model.Name.Trim();
            company.ShortQuote = model.ShortQuote.Trim();
            company.LongDescription = model.LongDescription.Trim();
            company.OfficeLocation = model.OfficeLocation.Trim();
            company.TechStack = model.TechStack.Trim();
            company.WebsiteUrl = model.WebsiteUrl.Trim();
            company.Size = model.Size;
            company.Founded = model.Founded;
            company.Industry = model.Industry;

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(CompanyDetails), new { name = company.Name });
        }

        #endregion

        #region Helper Methods

        private async Task<IEnumerable<CreateCompanyUserViewModel>> GetUsersWithNoCompanyAsync()
            => (await _context.Users
                    .Where(u => !_context.Companies.Select(c => c.UserId).Contains(u.Id))
                    .Select(u => new CreateCompanyUserViewModel
                    {
                        Id = u.Id,
                        DisplayName = u.DisplayName
                    }).ToListAsync());

        #endregion
    }
}
