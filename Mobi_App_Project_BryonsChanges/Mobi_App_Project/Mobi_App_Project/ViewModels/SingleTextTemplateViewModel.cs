using Mobi_App_Project.Helpers;
using Mobi_App_Project.Models;

namespace Mobi_App_Project.ViewModels
{
    public class SingleTextTemplateViewModel : BaseViewModel
    {
        public Question Question { get; set; }
        public Question NextQuestion { get; set; }
        public Result Result { get; set; }
        public AssessmentQuestion AssessmentQuestion { get; set; }
        public AssessmentQuestion NextAssessmentQuestion { get; set; }
        public TemplateNavigation TemplateNavigation { get; set; }

        public SingleTextTemplateViewModel(Question question, AssessmentQuestion assessmentQuestion)
        {
            Question = question;
            AssessmentQuestion = assessmentQuestion;

            Result = new Result();
            TemplateNavigation = new TemplateNavigation();
          
            NextAssessmentQuestion = App.AssesmentQuestionDB.GetNextAssessmentQuestion(App.Assessment.AssessmentId, AssessmentQuestion.OrderNum).Result;
            NextQuestion = App.QuestionDB.GetItemAsync(NextAssessmentQuestion.QuestionId).Result;
        }
    }
}
