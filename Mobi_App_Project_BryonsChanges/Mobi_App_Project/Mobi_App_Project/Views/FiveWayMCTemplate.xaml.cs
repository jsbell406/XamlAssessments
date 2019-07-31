﻿using Mobi_App_Project.Models;
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
            viewModel.Result.TextResults = result;
            await App.ResultDB.SaveItemAsync(viewModel.Result);

            if(!viewModel.IsLastQuestion)
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