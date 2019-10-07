using Mobi_App_Project.Models;
using Mobi_App_Project.ViewModels.Detail;
using Mobi_App_Project.ViewModels.Home;
using Mobi_App_Project.Views.Create;
using Mobi_App_Project.Views.Detail;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Mobi_App_Project.Views.Home
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Students : ContentPage
	{
        public StudentsViewModel viewModel;

        public Students()
        {
            InitializeComponent();
            BindingContext = viewModel = new StudentsViewModel();
        }

        private async void SelectedStudent(object sender, SelectedItemChangedEventArgs e)
        {
            Student student = e.SelectedItem as Student;
            if (student == null)
                return;

           
            await Navigation.PushModalAsync(new StudentDetail(new StudentDetailViewModel(student)));
        }

        async void Create_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new StudentCreate());
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            viewModel.StudentList.Clear();
            viewModel.Students.Clear();
            viewModel.FilteredList.Clear();
            viewModel.Students = App.StudentDB.GetItemsAsync().Result;
            viewModel.LoadStudentsCommand.Execute(true);
            SearchBar.Text = "";
        }
    }
}