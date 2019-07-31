using Mobi_App_Project.Helpers;
using Mobi_App_Project.Models;

namespace Mobi_App_Project.ViewModels
{
    public class TripleTextTemplateViewModel : BaseViewModel
    {
        public Question Question { get; set; }
        public Question NextQuestion { get; set; }
        public Result Result { get; set; }
        public AssessmentQuestion AssessmentQuestion { get; set; }
        public AssessmentQuestion NextAssessmentQuestion { get; set; }
        public TemplateNavigation TemplateNavigation { get; set; }
        public string StudentFullName
        {
            get
            {
                return string.Format("{0} {1}", App.Student.FirstName, App.Student.LastName);
            }
        }

        public string FirstAnswer { get; set; }
        public string SecondAnswer { get; set; }
        public string ThirdAnswer { get; set; }

        public string ResultString { get; private set; }

        public TripleTextTemplateViewModel(Question question, AssessmentQuestion assessmentQuestion) : base(question, assessmentQuestion)
        {
            Question = question;
            AssessmentQuestion = assessmentQuestion;

            Result = new Result();
            Result.QuestionId = question.QuestionId;
            Result.AssesmentQuestionId = assessmentQuestion.AssessmentQuestionId;
            Result.AssessmentSessionId = App.AssessmentSession.SessionId;
            TemplateNavigation = new TemplateNavigation();                  
        }

        public string BuildResultString()
        {
            string Delim = " :FULLSTOP: ";

            return ResultString = FirstAnswer + Delim + SecondAnswer + Delim + ThirdAnswer;
        }
    }
}
