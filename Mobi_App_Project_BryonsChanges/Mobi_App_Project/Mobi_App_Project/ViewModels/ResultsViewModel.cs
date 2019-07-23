using Mobi_App_Project.Models;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Mobi_App_Project.ViewModels
{
    public class ResultsViewModel : BaseViewModel
    {      
        public ObservableCollection<Result> ResultsList { get; set; }
        public Command LoadResultsCommand { get; set; }
        public string MyEditor { get; set;}

        public ResultsViewModel()
        {
            Title = "Browse Results";
            ResultsList = new ObservableCollection<Result>();
            LoadResultsCommand = new Command(async () => await ExecuteLoadResultsCommand());
        }

        async Task ExecuteLoadResultsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                ResultsList.Clear();
                var items = await App.ResultDB.GetResultsByAssessmentSession(App.AssessmentSession.SessionId);
                foreach (var item in items)
                {
                    ResultsList.Add(item);
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
