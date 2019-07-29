using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

using Mobi_App_Project.DB;
using Mobi_App_Project.Models;
using Xamarin.Forms;

namespace Mobi_App_Project.ViewModels
{
    public class AdminHomeViewModel : BaseViewModel
    {
        public ObservableCollection<Student> StudentList { get; set; }
        public Command LoadStudentListCommand { get; set; }


    }
}
