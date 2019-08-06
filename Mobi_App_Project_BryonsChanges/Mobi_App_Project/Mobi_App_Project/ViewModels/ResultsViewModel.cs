using Mobi_App_Project.Helpers;
using Mobi_App_Project.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Mobi_App_Project.ViewModels
{
    public class ResultsViewModel : BaseViewModel
    {      
        public ObservableCollection<Result> ResultsList { get; set; }
        public Command LoadResultsCommand { get; set; }
        public string MyEditor { get; set;}
        public Student Student { get; set; }

        public ResultsViewModel()
        {
            Title = "Browse Results";
            ResultsList = new ObservableCollection<Result>();
            LoadResultsCommand = new Command(async () => await ExecuteLoadResultsCommand());
            Student = App.Student;
        }

        async Task ExecuteLoadResultsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            List<Result> displayList = null;

            try
            {
                ResultsList.Clear();
                displayList = await App.ResultDB.GetResultsByAssessmentSession(App.AssessmentSession.SessionId);
                foreach (Result result in displayList)
                {
                    if(App.CurrentQuestions.Where(q => q.QuestionId == result.QuestionId).FirstOrDefault().Qtype == EnumHatersGonnaVerify.QType_TripleTextResponse)
                    {
                        string first = "";
                        string second = "";
                        string third = "";
                        string rawAnswer = result.TextResults;
                        string primaryDelim = ":FULLSTOP:";

                        int firstIndex = rawAnswer.IndexOf(primaryDelim);
                        first = rawAnswer.Substring(0, firstIndex).Trim();
                        string processAnswer = rawAnswer.Substring(firstIndex + primaryDelim.Length).Trim();
                        int secondIndex = processAnswer.IndexOf(primaryDelim);
                        second = processAnswer.Substring(0, secondIndex).Trim();
                        third = processAnswer.Substring(secondIndex + primaryDelim.Length).Trim();

                        result.TextResults = string.Format("1. {0}\n2. {1}\n3. {2}", first, second, third);
                    }
                    ResultsList.Add(result);
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
