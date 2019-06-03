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

namespace Mobi_App_Project.ViewModels
{
    public class IndividualStudentSelectionViewModel : BaseViewModel
    {
        public ObservableCollection<Student> studentList { get; set; }
        public Command LoadStudentListCommand { get; set; }

        public IndividualStudentSelectionViewModel()
        {
            studentList = new ObservableCollection<Student>();
            studentList.Add(new Student() { });
        }
    }
}
