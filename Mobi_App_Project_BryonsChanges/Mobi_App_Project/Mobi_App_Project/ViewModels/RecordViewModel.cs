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
    class RecordViewModel : BaseViewModel
    {
        public ObservableCollection<AssessmentSession> SearchDateList { get; set; }
        public ObservableCollection<AssessmentSession> DateList { get; set; }
        public Command LoadDateCommand { get; set; }
        public ICommand SearchCommand { get; set; }

        private List<AssessmentSession> assessmentSession;
        public List<AssessmentSession> AssessmentSession
        {
            get
            {
                return assessmentSession;
            }
            set
            {
                assessmentSession = value;
                OnPropertyChanged();
            }
        }

        private double searchedDate;
        public double SearchedDate
        {
            get { return searchedDate; }
            set { searchedDate = value; OnPropertyChanged(); }
        }

        public RecordViewModel()
        {
            Title = "Browse Session Date";
            SearchDateList = new ObservableCollection<AssessmentSession>();
            LoadDateCommand = new Command(async () => await ExecuteLoadDateCommand());

            DateList = new ObservableCollection<AssessmentSession>();
            AssessmentSession = App.AssesmentSessionDB.GetItemsAsync().Result;
            SearchCommand = new Command(async () => await SearchCommandExecute());

        }

        async Task SearchCommandExecute()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                DateList.Clear();
                var tempRecords = assessmentSession.Where(s => s.SessionDate.Contains(SearchedDate));
                foreach (var item in tempRecords)
                {
                    DateList.Add(item);
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

        async Task ExecuteLoadStudentsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                SearchDateList.Clear();
                var items = await App.AssesmentSessionDB.GetItemsAsync();
                foreach (var item in items)
                {
                    SearchDateList.Add(item);
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
