﻿using Mobi_App_Project.Helpers;
using Mobi_App_Project.Models;

namespace Mobi_App_Project.ViewModels
{
    public class FiveWayMCTemplateViewModel : BaseViewModel
    {
        public Question Question { get; set; }
        public Question NextQuestion { get; set; }
        public Result Result { get; set; }
        public AssessmentQuestion AssessmentQuestion { get; set; }
        public AssessmentQuestion NextAssessmentQuestion { get; set; }
        public TemplateNavigation TemplateNavigation { get; set; }
        public string StudentFullName { get
            {
                return string.Format("{0} {1}", App.Student.FirstName, App.Student.LastName);
            } }

        public string Opt1 { get; set; }
        public string Opt2 { get; set; }
        public string Opt3 { get; set; }
        public string Opt4 { get; set; }
        public string Opt5 { get; set; }

        public FiveWayMCTemplateViewModel(Question question, AssessmentQuestion assessmentQuestion) : base (question, assessmentQuestion)
        {
            Question = question;
            AssessmentQuestion = assessmentQuestion;
      
            OptionsParser();

            Result = new Result();
            Result.QuestionId = question.QuestionId;
            Result.AssesmentQuestionId = assessmentQuestion.AssessmentQuestionId;
            Result.AssessmentSessionId = App.AssessmentSession.SessionId;
            TemplateNavigation = new TemplateNavigation();           
        }

        private void OptionsParser()
        {
            char[] delim = ",".ToCharArray();
            string[] options = Question.Option1.Split(delim);
            Opt1 = options[0];
            Opt2 = options[1];
            Opt3 = options[2];
            Opt4 = options[3];
            Opt5 = options[4];
        }
    }
}
