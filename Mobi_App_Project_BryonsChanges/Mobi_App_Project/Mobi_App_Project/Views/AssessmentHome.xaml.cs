using Mobi_App_Project.Helpers;
using Mobi_App_Project.Models;
using Mobi_App_Project.ViewModels;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Mobi_App_Project.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AssessmentHome : ContentPage
	{
		public AssessmentHome ()
		{
			InitializeComponent ();        
            Title = "Assessment Title";
            List<AssessmentQuestion> assessmentQuestions = App.CurrentAssessmentQuestions;
            foreach(AssessmentQuestion assessmentQuestion in assessmentQuestions)
            {
                App.CurrentQuestions.Add(App.QuestionDB.GetItemAsync(assessmentQuestion.QuestionId).Result);
            }
            BindingContext = App.Assessment;          
		}

        async void Start_Clicked(object sender, EventArgs e)
        {
            AssessmentSession assessmentSession = new AssessmentSession();
            assessmentSession.AssessmentId = App.Assessment.AssessmentId;
            assessmentSession.StudentId = App.Student.StudentId;
            assessmentSession.SessionDate = JulianDateParser.ConverToJD(DateTime.Now);
            int success = App.AssesmentSessionDB.SaveItemAsync(assessmentSession).Result;
            if(success == 1)
            {
                App.AssessmentSession = assessmentSession;
                App.CurrentAssessmentSessionId = assessmentSession.SessionId;
            }

            Question question = App.CurrentQuestions[0];
            AssessmentQuestion assessmentQuestion = App.CurrentAssessmentQuestions[0];
            NavigateToNextQuestionViewAsync(question, assessmentQuestion);   
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