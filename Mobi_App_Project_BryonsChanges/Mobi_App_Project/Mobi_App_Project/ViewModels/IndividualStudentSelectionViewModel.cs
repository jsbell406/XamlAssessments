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
        public ObservableCollection<Student> studentList { get; set; }
        public ObservableCollection<Student> FilteredList { get; set; }
        public Command LoadStudentListCommand { get; set; }
        private ICommand _searchCommand;
        public ICommand SearchCommand
        {
            get
            {
                return _searchCommand ?? (_searchCommand = new Command<string>((text) =>
                {
                    FilteredList = (ObservableCollection<Student>)studentList.Where(s => s.FirstName.ToLower().StartsWith(text.ToLower()));  // text parameter can be used for searching 
                }));
            }
        }

        public IndividualStudentSelectionViewModel()
        {
            studentList = new ObservableCollection<Student>();
           // studentList.Add(new Student() { });
        }
    }
}
