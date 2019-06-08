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

        public AssessmentSelectionViewModel()
        {
            Title = "Browse Assessments";
            Assessments = new ObservableCollection<Assessment>();
            LoadAssessmentsCommand = new Command(async () => await ExecuteLoadAssessmentsCommand());
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
