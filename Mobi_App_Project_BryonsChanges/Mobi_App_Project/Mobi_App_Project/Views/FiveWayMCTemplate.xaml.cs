using Mobi_App_Project.Models;
using Mobi_App_Project.ViewModels;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Mobi_App_Project.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FiveWayMCTemplate : ContentPage
    {
        FiveWayMCTemplateViewModel viewModel;

        public FiveWayMCTemplate()
        {
            InitializeComponent();
        }
        public FiveWayMCTemplate(FiveWayMCTemplateViewModel vm)
        {
            InitializeComponent();
            BindingContext = viewModel = vm;
        }

        private async void HandleResult(string result)
        {
            viewModel.Result.AssesmentQuestionId = viewModel.Question.QuestionId;
            viewModel.Result.TextResults = result;
            viewModel.Result.QuestionId = viewModel.Question.QuestionId;
            viewModel.Result.AssesmentQuestionId = viewModel.AssessmentQuestion.AssessmentQuestionId;
            viewModel.Result.ResultId = await App.ResultDB.SaveItemAsync(viewModel.Result);

            NavigateToNextQuestionViewAsync(viewModel.NextQuestion, viewModel.NextAssessmentQuestion);
        }

        void Submit_Opt1_Clicked(object sender, EventArgs e)
        {
             HandleResult(viewModel.Opt1);          
        }

        void Submit_Opt2_Clicked(object sender, EventArgs e)
        {
            HandleResult(viewModel.Opt2);
        }

        void Submit_Opt3_Clicked(object sender, EventArgs e)
        {
            HandleResult(viewModel.Opt3);
        }

        void Submit_Opt4_Clicked(object sender, EventArgs e)
        {
            HandleResult(viewModel.Opt4);
        }

        void Submit_Opt5_Clicked(object sender, EventArgs e)
        {
            HandleResult(viewModel.Opt5);           
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