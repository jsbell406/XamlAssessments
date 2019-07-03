using Mobi_App_Project.Helpers;
using Mobi_App_Project.Models;
using Mobi_App_Project.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            viewModel.Result.ResuldId = await App.ResultDB.SaveItemAsync(viewModel.Result);

            // some sort of nav to next template passing next question
            viewModel.TemplateNavigation.NavigateToNextQuestionViewAsync(viewModel.NextQuestion,viewModel.NextAssessmentQuestion);
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
    }
}