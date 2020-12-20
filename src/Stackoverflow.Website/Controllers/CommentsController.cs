using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Stackoverflow.Website.BusinessModels;
using Stackoverflow.Website.DataAccess;
using Stackoverflow.Website.Services;
using Stackoverflow.Website.ViewModels;
using System.Threading.Tasks;

namespace Stackoverflow.Website.Controllers
{
    [Authorize]
    public class CommentsController : BaseController
    {
        private readonly ApplicationDbContext _context;
        public CommentsController(ApplicationDbContext context,
            IUserService userService) : base(userService)
        {
            _context = context;
        }

        #region Actions

        [HttpPost("[controller]/[action]")]
        public async Task<IActionResult> Create(CreateCommentViewModel model)
        {
            if (!ModelState.IsValid) return BadRequest("Error in entered data.");

            var post = await _context.Posts.FindAsync(model.PostId);

            if (post is null)
                return NotFound("Post does not exist.");

            var comment = new Comment
            {
                Description = model.Text.Trim(),
                PostId = post.Id,
                UserId = _userService.LoggedInUserId
            };

            await _context.Comments.AddAsync(comment);
            await _context.SaveChangesAsync();

            var questionId = post.Id;
            var relatedQuestion = await _context.Questions.FindAsync(post.Id);

            if (relatedQuestion is null)
            {
                var relatedAnswer = await _context.Answers.FindAsync(post.Id);

                questionId = relatedAnswer.QuestionId;
            }

            return RedirectToAction("Details", "Questions", new { questionId });
        }

        [HttpGet("[controller]/[action]")]
        public async Task<IActionResult> Delete(string id)
        {
            var comment = await _context.Comments.FindAsync(id);

            if (comment is null)
                return NotFoundView("Comment not found.");

            if (!comment.UserId.Equals(_userService.LoggedInUserId))
                return AccessDeniedView("Unauthorized to delete this comment.");

            var questionId = comment.Post.Id;
            _context.Comments.Remove(comment);
            await _context.SaveChangesAsync();

            var relatedQuestion = await _context.Questions.FindAsync(comment.Post.Id);

            if (relatedQuestion is null)
            {
                var relatedAnswer = await _context.Answers.FindAsync(comment.Post.Id);

                questionId = relatedAnswer.QuestionId;
            }

            return RedirectToAction("Details", "Questions", new { questionId });
        }

        #endregion
    }
}
