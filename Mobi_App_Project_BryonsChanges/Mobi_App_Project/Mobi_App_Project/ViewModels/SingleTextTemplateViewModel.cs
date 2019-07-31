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
        public string TextResult { get; set; }

        public SingleTextTemplateViewModel(Question question, AssessmentQuestion assessmentQuestion) : base(question,assessmentQuestion)
        {
            App.CurrentAssessmentQuestionId = assessmentQuestion.AssessmentQuestionId;
            App.CurrentQuestionId = question.QuestionId;
            Question = question;
            AssessmentQuestion = assessmentQuestion;

            //Result = new Result();
            //Result.QuestionId = question.QuestionId;
            //Result.AssesmentQuestionId = assessmentQuestion.AssessmentQuestionId;
            //Result.AssessmentSessionId = App.AssessmentSession.SessionId;
            // TemplateNavigation = new TemplateNavigation();          
        }
    }
}
