using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Stackoverflow.Website.BusinessModels;
using Stackoverflow.Website.DataAccess;
using Stackoverflow.Website.Services;
using Stackoverflow.Website.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Stackoverflow.Website.Controllers
{
    [Authorize]
    public class QuestionsController : BaseController
    {
        private readonly ApplicationDbContext _context;

        public QuestionsController(ApplicationDbContext context,
            IUserService userService) : base(userService)
        {
            _context = context;
        }

        #region Actions

        [AllowAnonymous]
        [HttpGet("[controller]")]
        public async Task<IActionResult> Index()
        {
            var allQuestionsVM = new AllQuestionsViewModel();
            var questions = await _context.Questions
                .OrderByDescending(q => q.CreatedDateUtc)
                .ToListAsync();

            foreach (var question in questions)
            {
                var q = new QuestionViewModel
                {
                    Id = question.Id,
                    Title = question.Title,
                    Views = question.Views,
                    Tags = question.Tags,
                    Description = question.Post.Description,
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
                    answerExist ? answers.First().EditedDateUtc : DateTime.UtcNow;
                q.AnswererDisplayName =
                    answerExist ? answers.First().Post.User.DisplayName : string.Empty;

                q.Votes =
                (await _context.Votes
                .CountAsync(v => v.PostId == question.Id && v.IsUpVote == true))
                - (await _context.Votes
                .CountAsync(v => v.PostId == question.Id && v.IsUpVote == false));

                allQuestionsVM.Questions.Add(q);
            }

            return View(allQuestionsVM);
        }

        [AllowAnonymous]
        [HttpGet("[controller]/{questionId}")]
        public async Task<IActionResult> Details(string questionId)
        {
            var question = await _context.Questions.FindAsync(questionId);

            if (question is null)
                return NotFoundView();

            var questionDetails = new QuestionDetailViewModel();
         
            var isUserLoggedIn = !string.IsNullOrEmpty(_userService.LoggedInUserId);

            questionDetails.Id = question.Id;
            questionDetails.CreatedDateUtc = question.CreatedDateUtc;
            questionDetails.EditedDateUtc = question.EditedDateUtc;
            questionDetails.Title = question.Title;
            questionDetails.Tags = question.Tags;
            questionDetails.Views = question.Views;
            questionDetails.Description = question.Post.Description;
            questionDetails.Code = question.Post.Code;
            questionDetails.CanComment = isUserLoggedIn;
            questionDetails.DisplayName = question.Post.User.DisplayName;
            questionDetails.CanAlterQuestion = isUserLoggedIn && question.Post.UserId.Equals(_userService.LoggedInUserId);

            questionDetails.VotesScore = 
                (await _context.Votes
                .CountAsync(v => v.PostId == question.Id && v.IsUpVote == true))
                - (await _context.Votes
                .CountAsync(v => v.PostId == question.Id && v.IsUpVote == false));
            
            if (isUserLoggedIn)
                questionDetails.CanVote = 
                    question.Post.UserId != _userService.LoggedInUserId && !await _context.Votes
                    .AnyAsync(v => v.PostId == question.Id && v.UserId == _userService.LoggedInUserId);

            questionDetails.Comments = await _context.Comments
                .Where(c => c.PostId == question.Id)
                .Select(c => new CommentViewModel
                {
                    Id = c.Id,
                    CreatedDateUtc = c.CreatedDateUtc,
                    Description = c.Description,
                    DisplayName = c.User.DisplayName,
                    CanAlterComment = isUserLoggedIn && c.UserId.Equals(_userService.LoggedInUserId)
                }).ToListAsync();

            var answersToQuestion = await _context.Answers
                .Where(q => q.QuestionId == question.Id).ToListAsync();

            var answersDetails = new List<AnswerDetailViewModel>();

            foreach (var answer in answersToQuestion)
            {
                var answerDetail = new AnswerDetailViewModel
                {
                    Id = answer.Id,
                    IsAccepted = answer.IsAccepted,
                    CreatedDateUtc = answer.CreatedDateUtc,
                    EditedDateUtc = answer.EditedDateUtc,
                    Description = answer.Post.Description,
                    Code = answer.Post.Code,
                    CanAlterAnswer =
                    isUserLoggedIn && answer.Post.UserId == _userService.LoggedInUserId,
                    DisplayName = answer.Post.User.DisplayName,
                    Comments = await _context.Comments
                    .Where(c => c.PostId == answer.Id)
                    .Select(c => new CommentViewModel
                    {
                        Id = c.Id,
                        CreatedDateUtc = c.CreatedDateUtc,
                        Description = c.Description,
                        DisplayName = c.User.DisplayName,
                        CanAlterComment = isUserLoggedIn && c.UserId.Equals(_userService.LoggedInUserId)
                    }).ToListAsync()
                };

                if (isUserLoggedIn)
                    answerDetail.CanVote = 
                        answer.Post.UserId != _userService.LoggedInUserId && !await _context.Votes
                    .AnyAsync(v => v.PostId == answer.Id && v.UserId == _userService.LoggedInUserId);

                answersDetails.Add(answerDetail);
            }

            questionDetails.Answers = answersDetails;
            question.Views += 1;
            await _context.SaveChangesAsync();

            return View(questionDetails);
        }

        [HttpGet("[controller]/[action]")]
        public IActionResult Create() => View();

        [HttpPost("[controller]/[action]")]
        public async Task<IActionResult> Create(CreateQuestionViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var post = await _context.Posts.AddAsync(new Post
            {
                Description = model.Description.Trim(),
                Code = model.Code.Trim(),
                UserId = _userService.LoggedInUserId
            });

            var question = await _context.Questions.AddAsync(new Question
            {
                Id = post.Entity.Id,
                Title = model.Title.Trim(),
                Tags = model.Tags
            });

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Details), new { questionId = question.Entity.Id });
        }

        [HttpGet("[controller]/[action]")]
        public async Task<IActionResult> Edit(string questionId)
        {
            if (string.IsNullOrEmpty(questionId)) return BadRequestView();

            var question = await _context.Questions.FindAsync(questionId);

            if (question is null) return NotFoundView();
            if (!question.Post.UserId.Equals(_userService.LoggedInUserId))
                return AccessDeniedView();

            return View(new EditQuestionViewModel
            {
                Id = question.Id,
                Description = question.Post.Description,
                Code = question.Post.Code,
                Tags = question.Tags,
                Title = question.Title
            });
        }

        [HttpPost("[controller]/[action]")]
        public async Task<IActionResult> Edit(EditQuestionViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var question = await _context.Questions.FindAsync(model.Id);

            if (question is null) return NotFoundView();

            if (!question.Post.UserId.Equals(_userService.LoggedInUserId))
                return AccessDeniedView();

            question.Tags = model.Tags.Trim();
            question.Title = model.Title.Trim();
            question.Post.Description = model.Description.Trim();
            question.Post.Code = model.Code.Trim();
            question.EditedDateUtc = DateTime.UtcNow;

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Details), new { questionId = question.Id });
        }

        [HttpGet("[controller]/{questionId}/[action]")]
        public async Task<IActionResult> Delete(string questionId)
        {
            if (string.IsNullOrEmpty(questionId)) return BadRequestView();

            var question = await _context.Questions.FindAsync(questionId);

            if (question is null) return NotFoundView();

            if (!question.Post.UserId.Equals(_userService.LoggedInUserId))
                return AccessDeniedView();

            _context.Posts.RemoveRange(_context.Answers.Where(a => a.QuestionId == question.Id).Select(a => a.Post));
            _context.Posts.Remove(question.Post);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
        
        #endregion
    }
}
