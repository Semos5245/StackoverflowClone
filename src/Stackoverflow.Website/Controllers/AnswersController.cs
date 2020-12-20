using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Stackoverflow.Website.BusinessModels;
using Stackoverflow.Website.DataAccess;
using Stackoverflow.Website.Services;
using Stackoverflow.Website.ViewModels;
using System;
using System.Threading.Tasks;

namespace Stackoverflow.Website.Controllers
{
    [Authorize]
    public class AnswersController : BaseController
    {
        private readonly ApplicationDbContext _context;
        public AnswersController(ApplicationDbContext context,
            IUserService userService) : base(userService)
        {
            _context = context;
        }

        #region Actions

        [HttpPost("[controller]/[action]")]
        public async Task<IActionResult> Create(CreateAnswerViewModel model)
        {
            if (!ModelState.IsValid) return BadRequestView();

            var question = await _context.Questions.FindAsync(model.QuestionId);

            if (question is null) return NotFoundView();

            var post = await _context.Posts.AddAsync(new Post
            {
                Description = model.Description.Trim(),
                Code = model.Code.Trim(),
                UserId = _userService.LoggedInUserId
            });

            await _context.AddAsync(new Answer
            {
                Id = post.Entity.Id,
                QuestionId = question.Id
            });

            await _context.SaveChangesAsync();

            return QuestionDetailsView(question.Id);
        }

        [HttpGet("[controller]/[action]")]
        public async Task<IActionResult> Edit(string answerId)
        {
            if (string.IsNullOrEmpty(answerId)) return BadRequestView();

            var answer = await _context.Answers.FindAsync(answerId);

            if (answer is null) return NotFoundView();
            if (!answer.Post.UserId.Equals(_userService.LoggedInUserId))
                return AccessDeniedView();

            return base.View(new EditAnswerViewModel
            {
                Description = answer.Post.Description,
                Code = answer.Post.Code,
                Id = answer.Id
            });
        }

        [HttpPost("[controller]/[action]")]
        public async Task<IActionResult> Edit(EditAnswerViewModel model)
        {
            if (!ModelState.IsValid) return BadRequestView();

            var answer = await _context.Answers.FindAsync(model.Id);

            if (answer is null) return NotFoundView();
            if (!answer.Post.UserId.Equals(_userService.LoggedInUserId))
                return AccessDeniedView();

            answer.Post.Description = model.Description.Trim();
            answer.Post.Code = model.Code.Trim();
            answer.EditedDateUtc = DateTime.UtcNow;

            await _context.SaveChangesAsync();

            return QuestionDetailsView(answer.QuestionId);
        }

        [HttpGet("[controller]/[action]")]
        public async Task<IActionResult> MarkAsAccepted(string answerId = "")
        {
            if (string.IsNullOrEmpty(answerId)) return BadRequestView();

            var answer = await _context.Answers.FindAsync(answerId);

            if (answer is null) return NotFoundView();
            if (!answer.Question.Post.UserId.Equals(_userService.LoggedInUserId))
                return AccessDeniedView();

            var previousAcceptedAnswer = await _context.Answers
                .SingleOrDefaultAsync(a => a.QuestionId == answer.QuestionId && a.IsAccepted == true);

            if (previousAcceptedAnswer != null)
            {
                previousAcceptedAnswer.IsAccepted = false;
                _context.Answers.Update(previousAcceptedAnswer);
            }

            answer.IsAccepted = true;
            _context.Answers.Update(answer);
            await _context.SaveChangesAsync();

            return QuestionDetailsView(answer.QuestionId);
        }

        [HttpGet("[controller]/[action]")]
        public async Task<IActionResult> Delete(string answerId)
        {
            if (string.IsNullOrEmpty(answerId)) return BadRequestView();

            var answer = await _context.Answers.FindAsync(answerId);

            if (answer is null) return NotFoundView();
            if (!answer.Post.UserId.Equals(_userService.LoggedInUserId))
                return AccessDeniedView();

            var relatedQuestionId = answer.QuestionId;

            _context.Posts.Remove(answer.Post);
            await _context.SaveChangesAsync();

            return QuestionDetailsView(relatedQuestionId);
        }
        
        #endregion

        #region Private Helper Methods

        private IActionResult QuestionDetailsView(string questionId)
        {
            return RedirectToAction("Details", "Questions", new { questionId });
        }

        #endregion
    }
}
