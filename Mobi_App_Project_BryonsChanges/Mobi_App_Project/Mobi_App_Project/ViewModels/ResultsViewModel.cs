using Mobi_App_Project.Models;
using Mobi_App_Project.DB;
using Mobi_App_Project.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Windows.Input;
using System.Linq;


namespace Mobi_App_Project.ViewModels
{
    public class ResultsViewModel : BaseViewModel
    {
        
        public ObservableCollection<Result> ResultsList { get; set; }
        public Command LoadResultsCommand { get; set; }
        public string MyEditor { get; set;}
        
        

        public ResultsViewModel()
        {
            Title = "Browse Reults";
            ResultsList = new ObservableCollection<Result>();
            LoadResultsCommand = new Command(async () => await ExecuteLoadResultsCommand());


            //AdminNotes = App.ResultDB.SaveItemAsync().Result;
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
        //private Task ExecuteLoadResultsCommand()
        //{
        //    throw new NotImplementedException();
        //}
    }
}
