using System;
using System.Linq;
using Mobi_App_Project.Helpers;
using Mobi_App_Project.Models;
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
            InitializeComponent();
            BindingContext = viewModel = new ResultsViewModel();                    
        }

        private async void SelectedResult(object sender, SelectedItemChangedEventArgs e)
        {
            Result selectedResult = e.SelectedItem as Result;
            Question selectedQuestion = App.CurrentQuestions.Where(q => q.QuestionId == selectedResult.QuestionId).FirstOrDefault();

            await DisplayAlert(selectedQuestion.DisplayText, selectedResult.TextResults, "Done");

        }

        async void Submit_Clicked(object sender, EventArgs e)
        {          
            App.AssessmentSession.AdminNotes = viewModel.MyEditor;
            int resultId = App.AssesmentSessionDB.SaveItemAsync(App.AssessmentSession).Result;
            App.CurrentAssessmentQuestions.Clear();
            App.CurrentQuestionId = 0;
            App.CurrentQuestions.Clear();
            App.Student = null;
            if (App.IsGroup)
            {
                //await Navigation.PushModalAsync(new NavigationPage(new AssessmentHome()));
            }
            else
            {
                await Navigation.PushModalAsync(new NavigationPage(new AdminHome()));
                Navigation.RemovePage(this);
            }
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            viewModel.LoadResultsCommand.Execute(true);
        }
    }
}