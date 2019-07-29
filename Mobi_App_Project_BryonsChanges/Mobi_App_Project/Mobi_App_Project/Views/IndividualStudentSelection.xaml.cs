using Mobi_App_Project.ViewModels;
using System;
using Mobi_App_Project.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Mobi_App_Project.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class IndividualStudentSelection : ContentPage
	{
        public IndividualStudentSelectionViewModel viewModel;

        public IndividualStudentSelection()
		{          
            InitializeComponent();          
            BindingContext = viewModel = new IndividualStudentSelectionViewModel();     
        }
     
        private async void SelectedStudent(object sender, SelectedItemChangedEventArgs e)
        {
            Student student = e.SelectedItem as Student;
            if (student == null)
                return;

            App.Student = student;
            await Navigation.PushAsync(new AssessmentSelection());         
        }

        async void Create_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NewStudentForm());
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            viewModel.StudentList.Clear();
            viewModel.Students.Clear();
            viewModel.FilteredList.Clear();
            viewModel.Students = App.StudentDB.GetItemsAsync().Result;
            viewModel.LoadStudentsCommand.Execute(true);
        }
    }
}