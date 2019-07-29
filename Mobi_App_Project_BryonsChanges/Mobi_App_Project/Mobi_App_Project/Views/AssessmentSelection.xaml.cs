using Mobi_App_Project.Models;
using Mobi_App_Project.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Mobi_App_Project.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AssessmentSelection : ContentPage
	{
        AssessmentSelectionViewModel viewModel;

		public AssessmentSelection()
		{
			InitializeComponent ();
            BindingContext = viewModel = new AssessmentSelectionViewModel();
		}

        async void OnAssessmentSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var assessment = args.SelectedItem as Assessment;
            if (assessment == null)
                return;

            // TODO: verify assessment gets set in app
            App.Assessment = assessment;

            Task<List<AssessmentQuestion>> assessmentQuestionsInTask = App.AssesmentQuestionDB.GetAssessmentQuestionsByAssessmentId(App.Assessment.AssessmentId);
            List<AssessmentQuestion> assessmentQuestions = assessmentQuestionsInTask.Result;
            AssessmentQuestion[] assessmentQuestionsArray = new AssessmentQuestion[assessmentQuestions.Count];

            foreach(AssessmentQuestion assessmentQuestion in assessmentQuestions)
            {
                assessmentQuestionsArray[assessmentQuestion.OrderNum - 1] = assessmentQuestion;
            }

            App.CurrentAssessmentQuestions.AddRange(assessmentQuestionsArray);

            await Navigation.PushAsync(new AssessmentHome());

            AssessmentListView.SelectedItem = null;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            viewModel.LoadAssessmentsCommand.Execute(true);
        }
    }
}