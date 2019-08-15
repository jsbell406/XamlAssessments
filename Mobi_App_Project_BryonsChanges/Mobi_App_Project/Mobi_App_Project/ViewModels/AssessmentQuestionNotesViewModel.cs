using Mobi_App_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mobi_App_Project.ViewModels
{
    public class AssessmentQuestionNotesViewModel : BaseViewModel
    {
        public Result Result { get; set; }
        public Question Question { get; set; }

        public AssessmentQuestionNotesViewModel(Result result)
        {
            Result = result;
            Question = App.CurrentQuestions.Where(q => q.QuestionId == result.QuestionId).FirstOrDefault();
        }
        public AssessmentQuestionNotesViewModel()
        {
           
        }
    }
}
