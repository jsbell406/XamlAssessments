using Mobi_App_Project.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mobi_App_Project.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Collections.ObjectModel;

namespace Mobi_App_Project.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class IndividualStudentSelection : ContentPage
	{

        Student student = new Student();
        //List<string> studentList = new List<string>
        //{
        //    "FirstName", "LastName"
        //};
        IndividualStudentSelectionViewModel vm = new IndividualStudentSelectionViewModel();
        ObservableCollection<Student> myStudents = new ObservableCollection<Student>();
        
        private int c;

        public IndividualStudentSelection()
		{
            
            InitializeComponent();
            //bool check = true;
           
            this.BindingContext = vm = new IndividualStudentSelectionViewModel();
            
        
        }
        private void SelectedStudent(object sender, EventArgs e)
        {
           // BindingContext = new IndividualStudentSelectionViewModel();
        }


        private void StudentSearchBar_SearchButtonPressed(object sender, EventArgs e)
        {
            BindingContext = new IndividualStudentSelectionViewModel();
        }

        //private void StudentSearchBar_TextChanged(object sender, TextChangedEventArgs e)
        //{
        //    var keyword = StudentSearchBar.Text;
        //    if(keyword.Length >= 1)
        //    {
                
        //        var suggestions = vm.studentList.Where(c => c.FirstName.ToLower().StartsWith(keyword.ToLower()));
        //        // var s = from c in studentList where c.Contains(keyword) select c;
        //        SuggestionsListView.ItemsSource = suggestions;
        //        SuggestionsListView.IsVisible = true;
                
        //    }
        //    else
        //    {
        //        SuggestionsListView.IsVisible = false;
        //    }
            

        //}

        //private void SuggestionsListView_ItemTapped(object sender, ItemTappedEventArgs e)
        //{
        //    var selection = e.Item as Student;
        //    myStudents.Add(selection);
        //    StudentListView.ItemsSource = myStudents;
        //    SuggestionsListView.IsVisible = false;
        //    //App.StudentDB.SaveItemAsync();
        //}
    }
}