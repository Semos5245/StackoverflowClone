using System;

namespace Stackoverflow.Website.ViewModels
{
    public class QuestionViewModel
    {
        public string Id { get; set; }
        public string Title { get; set; }   
        public string AskerDisplayName { get; set; }
        public string Description { get; set; }
        public int Votes { get; set; }
        public int Views { get; set; }
        public int Answers { get; set; }
        public string Tags { get; set; }
        public DateTime AskedFromUtc { get; set; }
        public DateTime? AnsweredFromUtc { get; set; }
        public bool HasAcceptedAnswer { get; set; }
        public string AnswererDisplayName { get; set; }
    }
}
