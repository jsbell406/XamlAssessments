using Mobi_App_Project.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Mobi_App_Project.ViewModels.Home
{
    public class StudentsViewModel : BaseViewModel
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

        public StudentsViewModel()
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
                var tempRecords = students.Where(s => s.ToString().ToUpper().Contains(SearchedText.ToUpper()));
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
                List<Student> students = await App.StudentDB.GetItemsAsync();
                foreach (Student student in students)
                {
                    StudentList.Add(student);
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
