using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Stackoverflow.Website.DataAccess;
using Stackoverflow.Website.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Stackoverflow.Website.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            // Get top viewed Questions
            var topQuestions = new List<QuestionViewModel>();

            foreach (var question in await _context.Questions
                    .OrderByDescending(q => q.Views)
                    .ThenBy(q => q.CreatedDateUtc)
                    .Take(70).ToListAsync())
            {
                var q = new QuestionViewModel
                {
                    Id = question.Id,
                    Title = question.Title,
                    Views = question.Views,
                    Tags = question.Tags,
                    AskerDisplayName = question.Post.User.DisplayName,
                    AskedFromUtc = question.CreatedDateUtc
                };

                var answers = await _context.Answers
                    .Where(q => q.QuestionId == question.Id)
                    .OrderByDescending(q => q.CreatedDateUtc)
                    .ToListAsync();

                var answerExist = answers.Any();

                q.Answers = answers.Count;
                q.HasAcceptedAnswer = answers.Any(a => a.IsAccepted);
                q.AnsweredFromUtc =
                    answerExist ? answers.First().EditedDateUtc : (DateTime?)null;
                q.AnswererDisplayName =
                    answerExist ? answers.First().Post.User.DisplayName : string.Empty;

                q.Votes =
                (await _context.Votes
                .CountAsync(v => v.PostId == question.Id && v.IsUpVote == true))
                - (await _context.Votes
                .CountAsync(v => v.PostId == question.Id && v.IsUpVote == false));

                topQuestions.Add(q);
            }

            return View(topQuestions);
        }
    }
}
