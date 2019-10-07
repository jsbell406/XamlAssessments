using Mobi_App_Project.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Mobi_App_Project.ViewModels
{
    public class AssessmentSelectionViewModel : BaseViewModel
    {
        public ObservableCollection<Assessment> Assessments { get; set; }
        public Command LoadAssessmentsCommand { get; set; }
        private List<Question> Questions { get; set; }      
        public string StudentFullName { get
            {
                return string.Format("{0} {1}", App.Student.FirstName, App.Student.LastName);
            } }

        public string StudentsAssessHomeDisplay { get
            {
                if(StudentFullName.EndsWith("s"))
                {
                    return string.Format("{0}'", StudentFullName);
                }
                else
                {
                    return string.Format("{0}'s", StudentFullName);
                }
                
            } }
        public Assessment Assessment { get; set; }
        public AssessmentSelectionViewModel()
        {
            Title = "Browse Assessments";
            Assessments = new ObservableCollection<Assessment>();
            Questions = new List<Question>();
            LoadAssessmentsCommand = new Command(async () => await ExecuteLoadAssessmentsCommand());
            App.CurrentAssessmentQuestions = new List<AssessmentQuestion>();
          
        }
        public void LoadAssessmentQuestions()
        {
             
            Task<List<AssessmentQuestion>> assessmentQuestionsInTask = App.AssesmentQuestionDB.GetAssessmentQuestionsByAssessmentId(App.Assessment.AssessmentId);
            List<AssessmentQuestion> assessmentQuestions = assessmentQuestionsInTask.Result;
            AssessmentQuestion[] assessmentQuestionsArray = new AssessmentQuestion[assessmentQuestions.Count];

            foreach (AssessmentQuestion assessmentQuestion in assessmentQuestions)
            {
                assessmentQuestionsArray[assessmentQuestion.OrderNum - 1] = assessmentQuestion;
            }

            App.CurrentAssessmentQuestions.AddRange(assessmentQuestionsArray);
                     
        }

        async Task ExecuteLoadAssessmentsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;
            try
            {
                Assessments.Clear();
                
                var assessments = await App.AssesmentDB.GetItemsAsync();
                foreach(var assessment in assessments)
                {
                    Assessments.Add(assessment);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
