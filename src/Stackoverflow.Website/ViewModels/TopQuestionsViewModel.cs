using System.Collections.Generic;

namespace Stackoverflow.Website.ViewModels
{
    public class TopQuestionsViewModel
    {
        public IList<QuestionViewModel> Questions { get; set; }

        public TopQuestionsViewModel()
        {
            Questions = new List<QuestionViewModel>();
        }
    }
}
