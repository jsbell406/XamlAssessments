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

            viewModel.Result.AssesmentQuestionId = viewModel.Question.QuestionId;
            viewModel.Result.TextResults = result;
            viewModel.Result.QuestionId = viewModel.Question.QuestionId;
            viewModel.Result.AssesmentQuestionId = viewModel.AssessmentQuestion.AssessmentQuestionId;
            viewModel.Result.ResuldId = await App.ResultDB.SaveItemAsync(viewModel.Result);

            NavigateToNextQuestionViewAsync(viewModel.NextQuestion, viewModel.NextAssessmentQuestion);
        }

        public async void NavigateToNextQuestionViewAsync(Question question, AssessmentQuestion assessmentQuestion)
        {
            switch (question.Qtype)
            {
                case "5WayMC":
                    await Navigation.PushAsync(new FiveWayMCTemplate(new FiveWayMCTemplateViewModel(question, assessmentQuestion)));
                    break;
                case "3WayMC":
                    await Navigation.PushAsync(new ThreeWayMCTemplate(new ThreeWayMCTemplateViewModel(question, assessmentQuestion)));
                    break;
                case "2WayMC":
                    await Navigation.PushAsync(new TwoWayMCTemplate(new TwoWayMCTemplateViewModel(question, assessmentQuestion)));
                    break;
                case "SingleText":
                    await Navigation.PushAsync(new SingleTextTemplate(new SingleTextTemplateViewModel(question, assessmentQuestion)));
                    break;
                case "TripleText":
                    await Navigation.PushAsync(new TripleTextTemplate(new TripleTextTemplateViewModel(question, assessmentQuestion)));
                    break;
                default:
                    await Navigation.PushModalAsync(new AssessmentHome());
                    break;
            }
        }
    }
}