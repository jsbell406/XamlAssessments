using System;
using Mobi_App_Project.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Mobi_App_Project.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Results : ContentPage
    {
        ResultsViewModel viewModel;

        public Results()
        {      
            BindingContext = viewModel = new ResultsViewModel();
            InitializeComponent();           
        }

        private async void SelectedResult(object sender, EventArgs e)
        {
            //Possible addition to view result answer in pop up box            
        }

        async void Submit_Clicked(object sender, EventArgs e)
        {          
            App.AssessmentSession.AdminNotes = viewModel.MyEditor;
            int resultId = App.AssesmentSessionDB.SaveItemAsync(App.AssessmentSession).Result;
            App.CurrentAssessmentQuestions.Clear();
            App.CurrentQuestion = 0;
            App.CurrentQuestions.Clear();
            App.Student = null;
            if (App.IsGroup)
            {
                await Navigation.PushModalAsync(new NavigationPage(new AssessmentHome()));
            }
            else
            {
                await Navigation.PushModalAsync(new NavigationPage(new AdminHome()));
            }
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            viewModel.LoadResultsCommand.Execute(true);
        }
    }
}