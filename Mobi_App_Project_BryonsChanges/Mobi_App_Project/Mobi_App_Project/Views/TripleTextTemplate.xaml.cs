using Mobi_App_Project.Models;
using Mobi_App_Project.ViewModels;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Mobi_App_Project.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class TripleTextTemplate : ContentPage
	{
        TripleTextTemplateViewModel viewModel;

		public TripleTextTemplate ()
		{
			InitializeComponent ();
		}

        public TripleTextTemplate(TripleTextTemplateViewModel vm)
        {
            InitializeComponent();
            BindingContext = viewModel = vm;
        }

        void First_OnEditorCompleted(object sender, EventArgs e)
        {
            viewModel.FirstAnswer = ((Editor)sender).Text;
        }

        void Second_OnEditorCompleted(object sender, EventArgs e)
        {
            viewModel.SecondAnswer = ((Editor)sender).Text;    
        }

        void Third_OnEditorCompleted(object sender, EventArgs e)
        {
            viewModel.ThirdAnswer = ((Editor)sender).Text;      
        }

        void Done_Clicked(object sender, EventArgs e)
        {
            HandleResult();
        }

        private async void HandleResult()
        {
            string result = viewModel.BuildResultString();

            viewModel.Result.TextResults = result;
            await App.ResultDB.SaveItemAsync(viewModel.Result);

            if (!viewModel.IsLastQuestion)
            {
                viewModel.NextAssessmentQuestion = App.CurrentAssessmentQuestions[viewModel.AssessmentQuestion.OrderNum];
                viewModel.NextQuestion = App.CurrentQuestions[viewModel.AssessmentQuestion.OrderNum];
                NavigateToNextQuestionViewAsync(viewModel.NextQuestion, viewModel.NextAssessmentQuestion);
            }
            else
            {
                await Navigation.PushModalAsync(new Results(), false);
            }
        }

        public async void NavigateToNextQuestionViewAsync(Question question, AssessmentQuestion assessmentQuestion)
        {
            switch (question.Qtype)
            {
                case "5WayMC":
                    await Navigation.PushModalAsync(new FiveWayMCTemplate(new FiveWayMCTemplateViewModel(question, assessmentQuestion)));
                    break;
                case "3WayMC":
                    await Navigation.PushModalAsync(new ThreeWayMCTemplate(new ThreeWayMCTemplateViewModel(question, assessmentQuestion)));
                    break;
                case "2WayMC":
                    await Navigation.PushModalAsync(new TwoWayMCTemplate(new TwoWayMCTemplateViewModel(question, assessmentQuestion)));
                    break;
                case "SingleText":
                    await Navigation.PushModalAsync(new SingleTextTemplate(new SingleTextTemplateViewModel(question, assessmentQuestion)));
                    break;
                case "TripleText":
                    await Navigation.PushModalAsync(new TripleTextTemplate(new TripleTextTemplateViewModel(question, assessmentQuestion)));
                    break;
                default:
                    await Navigation.PushModalAsync(new AdminHome());
                    break;
            }
        }
    }
}