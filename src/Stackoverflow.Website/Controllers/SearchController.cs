using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Stackoverflow.Website.DataAccess;
using Stackoverflow.Website.Services;
using Stackoverflow.Website.ViewModels;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Stackoverflow.Website.Controllers
{
    [Authorize]
    public class SearchController : BaseController
    {
        private readonly ApplicationDbContext _context;
        public SearchController(ApplicationDbContext context,
            IUserService userService) : base(userService)
        {
            _context = context;
        }

        [AllowAnonymous]
        [HttpGet("[controller]")]
        public async Task<IActionResult> Index(string query = null)
        {
            ViewData["Query"] = query?.Trim() ?? string.Empty;
            var allQuestionsVM = new AllQuestionsViewModel();
            var questionsQuery = _context.Questions.AsQueryable();
                
            if (!string.IsNullOrEmpty(query))
            {
                questionsQuery = questionsQuery.Where(q => q.Title.Contains(query.Trim()));
            }

            var questions = await questionsQuery
                .OrderByDescending(q => q.CreatedDateUtc).ToListAsync();

            foreach (var question in questions)
            {
                var q = new QuestionViewModel
                {
                    Title = question.Title,
                    Views = question.Views,
                    Tags = question.Tags,
                    AskerDisplayName = question.Post.User.DisplayName,
                    AskedFromUtc = question.CreatedDateUtc,
                    Description = question.Post.Description
                };

                var answers = await _context.Answers
                    .Where(q => q.QuestionId == question.Id)
                    .OrderByDescending(q => q.CreatedDateUtc)
                    .Select(a => new
                    {
                        a.IsAccepted,
                        a.EditedDateUtc,
                        AnswererDisplayName = a.Post.User.DisplayName
                    }).ToListAsync();

                var answerExist = answers.Any();

                q.Answers = answers.Count;
                q.HasAcceptedAnswer = answers.Any(a => a.IsAccepted);
                q.AnsweredFromUtc =
                    answerExist ? answers.First().EditedDateUtc : (DateTime?)null;
                q.AnswererDisplayName =
                    answerExist ? answers.First().AnswererDisplayName : string.Empty;
                
                q.Votes =
                (await _context.Votes
                .CountAsync(v => v.PostId == question.Id && v.IsUpVote == true))
                - (await _context.Votes
                .CountAsync(v => v.PostId == question.Id && v.IsUpVote == false));

                allQuestionsVM.Questions.Add(q);
            }

            return View(allQuestionsVM);
        }
    }
}
