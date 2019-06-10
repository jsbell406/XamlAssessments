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
    public class IndividualStudentSelectionViewModel : BaseViewModel
    {
        public ObservableCollection<Student> StudentList { get; set; }
        public ObservableCollection<Student> FilteredList { get; set; }
        public Command LoadStudentsCommand { get; set; }
        public ICommand SearchCommand { get; set; }

        private List<Student> students;
        public List<Student> Students
        {
            get
            {
                return students;
            }
            set
            {
                students = value;
                OnPropertyChanged();
            }
        }

        private string searchedText;
        public string SearchedText
        {
            get { return searchedText; }
            set { searchedText = value; OnPropertyChanged(); }
        }

      


        public IndividualStudentSelectionViewModel()
        {
            Title = "Browse Students";
            StudentList = new ObservableCollection<Student>();
            LoadStudentsCommand = new Command(async () => await ExecuteLoadStudentsCommand());

            FilteredList = new ObservableCollection<Student>();
            Students = App.StudentDB.GetItemsAsync().Result;
            SearchCommand = new Command(async () => await SearchCommandExecute());
        
        }

        async Task SearchCommandExecute()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                FilteredList.Clear();
                var tempRecords = students.Where(s => s.FirstName.Contains(SearchedText));
                foreach (var item in tempRecords)
                {
                    FilteredList.Add(item);
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
                StudentList.Clear();
                var items = await App.StudentDB.GetItemsAsync();
                foreach (var item in items)
                {
                    StudentList.Add(item);
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
   
            
   
