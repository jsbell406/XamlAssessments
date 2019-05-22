using Mobi_App_Project.DB;
using Mobi_App_Project.Models;
using System.Collections.Generic;

namespace Mobi_App_Project.ViewModels
{
    public class QuestionViewModel : BaseViewModel
    {
        private int studentId;
        private int questionNumber;
        private int assessmentId;
        StudentDB studentDB = App.StudentDB;
        AssesmentDB assesmentDB = App.AssesmentDB;
        QuestionDB questionDB = App.QuestionDB;
        AssesmentQuestionDB assesmentQuestionDB = App.AssesmentQuestionDB;
        ResultDB resultDB = App.ResultDB;
        public Student Student { get; set; }
       // public Assessment Assessment { get; set; }
        public Question Question { get; set; }
        public Result Result { get; set; } = new Result();



        public QuestionViewModel()
        {
        }

        public QuestionViewModel(int  studentId, int questionNumber, int assessmentId)
        {

            this.studentId = studentId;
            this.questionNumber = questionNumber;
            this.assessmentId = assessmentId;
            init();
        }

        public object adminUsers { get; private set; }

        private async void init()
        {
            try
            {
               
               //adminUsers = new List<AdminUser>();
               //adminUsers.Add(await userDB.GetItemAsync(1));
               adminUsers = await userDB.GetItemsAsync();
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }
        }
    }
}