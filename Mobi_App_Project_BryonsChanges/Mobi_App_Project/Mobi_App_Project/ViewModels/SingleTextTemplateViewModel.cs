using Mobi_App_Project.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mobi_App_Project.ViewModels
{
    public class SingleTextTemplateViewModel : BaseViewModel
    {
        public Question Question { get; set; }
        public AssessmentQuestion AssessmentQuestion {get;set;}

        public SingleTextTemplateViewModel(Question question, AssessmentQuestion assessmentQuestion)
        {
            Question = question;
            AssessmentQuestion = assessmentQuestion;
        }
    }
}
