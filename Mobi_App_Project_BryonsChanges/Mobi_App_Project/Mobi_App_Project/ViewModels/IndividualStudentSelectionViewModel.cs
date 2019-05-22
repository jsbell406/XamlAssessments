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
    public class IndividualStudentSelectionViewModel : BaseViewModel
    {
        public ObservableCollection<Student> StudentList { get; set; }
        public Command LoadStudentListCommand { get; set; }

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                StudentList.Clear();
                var Students = await App.StudentDB.GetItemsAsync();
                foreach (var student in Students)
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
