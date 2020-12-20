using System.Collections.Generic;

namespace Stackoverflow.Website.ViewModels
{
    public class AllQuestionsViewModel
    {
        public IList<QuestionViewModel> Questions { get; set; }
        public AllQuestionsViewModel()
        {
            Questions = new List<QuestionViewModel>();
        }
    }
}
