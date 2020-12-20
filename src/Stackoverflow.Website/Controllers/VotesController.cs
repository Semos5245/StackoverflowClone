using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Stackoverflow.Website.BusinessModels;
using Stackoverflow.Website.DataAccess;
using Stackoverflow.Website.Services;
using System.Threading.Tasks;

namespace Stackoverflow.Website.Controllers
{
    [Authorize]
    public class VotesController : BaseController
    {
        private readonly ApplicationDbContext _context;

        public VotesController(
            ApplicationDbContext context,
            IUserService userService) : base(userService)
        {
            _context = context;
        }

        [HttpGet("[controller]/[action]")]
        public async Task<IActionResult> UpVote(string postId = "")
        {
            var post = await _context.Posts.FindAsync(postId);

            if (post is null)
                return NotFoundView("Post does not exist");

            if (post.UserId.Equals(_userService.LoggedInUserId))
                return BadRequestView("Can't vote for your own posts");

            var existingVote = await _context.Votes.SingleOrDefaultAsync
                (v => v.PostId == post.Id && v.UserId == _userService.LoggedInUserId);

            if (existingVote != null)
                return BadRequestView("You have previously voted to this post");

            await _context.Votes.AddAsync(new Vote
            {
                IsUpVote = true,
                PostId = post.Id,
                UserId = _userService.LoggedInUserId
            });

            await _context.SaveChangesAsync();

            var questionId = post.Id;
            var relatedQuestion = await _context.Questions.SingleOrDefaultAsync
                (q => q.Id == questionId);

            if (relatedQuestion is null)
            {
                var relatedAnswer = await _context.Answers.FindAsync(post.Id);
                questionId = relatedAnswer.QuestionId;
            }

            return RedirectToAction("Details", "Questions", new { questionId });
        }

        [HttpGet("[controller]/[action]")]
        public async Task<IActionResult> DownVote(string postId = "")
        {
            var post = await _context.Posts.FindAsync(postId);

            if (post is null)
                return NotFoundView("Post does not exist");

            if (post.UserId.Equals(_userService.LoggedInUserId))
                return BadRequestView("Can't vote for your own posts");

            var existingVote = await _context.Votes.SingleOrDefaultAsync
                (v => v.PostId == post.Id && v.UserId == _userService.LoggedInUserId);

            if (existingVote != null)
                return BadRequestView("You have previously voted to this post");

            await _context.Votes.AddAsync(new Vote
            {
                IsUpVote = false,
                PostId = post.Id,
                UserId = _userService.LoggedInUserId
            });

            await _context.SaveChangesAsync();

            var questionId = post.Id;
            var relatedQuestion = await _context.Questions.SingleOrDefaultAsync
                (q => q.Id == questionId);

            if (relatedQuestion is null)
            {
                var relatedAnswer = await _context.Answers.FindAsync(post.Id);
                questionId = relatedAnswer.QuestionId;
            }

            return RedirectToAction("Details", "Questions", new { questionId });
        }
    }
}
