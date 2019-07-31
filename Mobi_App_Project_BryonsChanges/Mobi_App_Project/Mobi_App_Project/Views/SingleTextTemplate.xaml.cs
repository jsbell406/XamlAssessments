using Mobi_App_Project.Models;
using Mobi_App_Project.ViewModels;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Mobi_App_Project.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SingleTextTemplate : ContentPage
	{
        SingleTextTemplateViewModel viewModel;
        
		public SingleTextTemplate ()
		{
			InitializeComponent ();
		}

        public SingleTextTemplate(SingleTextTemplateViewModel vm)
        {
            InitializeComponent();
            BindingContext = viewModel = vm;
        }

        void OnEditorTextChanged(object sender, TextChangedEventArgs e)
        {
            //string oldText = e.OldTextValue;
            //string newText = e.NewTextValue;
        }
        void Done_Clicked(object sender, EventArgs e)
        {
            HandleResult();
        }
        void OnEditorCompleted(object sender, EventArgs e)
        {
            //HandleResult();
            //viewModel.Result = new Result();
            //viewModel.Result.QuestionId = App.CurrentQuestionId;
            //viewModel.Result.AssesmentQuestionId = App.CurrentAssessmentQuestionId;
            //viewModel.Result.AssessmentSessionId = App.AssessmentSession.SessionId;
            //viewModel.Result.TextResults = ((Editor)sender).Text;

            //await App.ResultDB.SaveItemAsync(viewModel.Result);
            //if (!viewModel.IsLastQuestion)
            //{
            //    viewModel.NextAssessmentQuestion = App.CurrentAssessmentQuestions[viewModel.AssessmentQuestion.OrderNum];
            //    viewModel.NextQuestion = App.CurrentQuestions[viewModel.AssessmentQuestion.OrderNum];
            //    NavigateToNextQuestionViewAsync(viewModel.NextQuestion, viewModel.NextAssessmentQuestion);
            //}
            //else
            //{
            //    await Navigation.PushAsync(new Results());
            //}
        }
        private async void HandleResult()
        {
            viewModel.Result = new Result();
            viewModel.Result.QuestionId = App.CurrentQuestionId;
            viewModel.Result.AssesmentQuestionId = App.CurrentAssessmentQuestionId;
            viewModel.Result.AssessmentSessionId = App.AssessmentSession.SessionId;
            viewModel.Result.TextResults = viewModel.TextResult;

            await App.ResultDB.SaveItemAsync(viewModel.Result);
            if (!viewModel.IsLastQuestion)
            {
                viewModel.NextAssessmentQuestion = App.CurrentAssessmentQuestions[viewModel.AssessmentQuestion.OrderNum];
                viewModel.NextQuestion = App.CurrentQuestions[viewModel.AssessmentQuestion.OrderNum];
                NavigateToNextQuestionViewAsync(viewModel.NextQuestion, viewModel.NextAssessmentQuestion);
            }
            else
            {
                await Navigation.PushAsync(new Results());
            }
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