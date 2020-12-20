using System;
using System.Collections.Generic;

namespace Stackoverflow.Website.ViewModels
{
    public class QuestionDetailViewModel
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Code { get; set; }
        public int VotesScore { get; set; }
        public bool CanVote { get; set; }
        public DateTime CreatedDateUtc { get; set; }
        public DateTime EditedDateUtc { get; set; }
        public string DisplayName { get; set; }
        public int Views { get; set; }
        public string Tags { get; set; }
        public bool CanAlterQuestion { get; set; }
        public bool CanComment { get; set; }
        public IList<CommentViewModel> Comments { get; set; }
        public IList<AnswerDetailViewModel> Answers { get; set; }
    }

    public class AnswerDetailViewModel
    {
        public string Id { get; set; }
        public string Description { get; set; }
        public string Code { get; set; }
        public bool IsAccepted { get; set; }
        public int VotesScore { get; set; }
        public bool CanVote { get; set; }
        public bool CanAlterAnswer { get; set; }
        public DateTime CreatedDateUtc { get; set; }
        public DateTime EditedDateUtc { get; set; }
        public string DisplayName { get; set; }
        public IList<CommentViewModel> Comments { get; set; }
    }

    public class CommentViewModel 
    {
        public string Id { get; set; }
        public string Description { get; set; }
        public string DisplayName { get; set; }
        public bool CanAlterComment { get; set; }
        public DateTime CreatedDateUtc { get; set; }
    }
}
