using Mobi_App_Project.Models;
using Mobi_App_Project.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
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
            btnNotesDone.IsEnabled = true;
            questionNotes.IsVisible = false;
            notesButton.IsVisible = false;
        }

        public TripleTextTemplate(TripleTextTemplateViewModel vm)
        {
            InitializeComponent();
            BindingContext = viewModel = vm;
            btnNotesDone.IsEnabled = true;
            questionNotes.IsVisible = false;
            notesButton.IsVisible = false;
            
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
            viewModel.Result.AssessmentQuestionInstructorNotes = questionNotes.Text;
            HandleResult();
        }
        async void Notes_Clicked(object sender, EventArgs e)
        {
            
            btnNotesDone.IsEnabled = false;
            questionNotes.IsVisible = true;
            notesButton.IsVisible = true;

            //Editor editor = new Editor
            //{
            //    AutomationId = "questionNotes",
            //    VerticalOptions = LayoutOptions.FillAndExpand,
            //    HorizontalOptions = LayoutOptions.FillAndExpand
            //};
            //editor.SetBinding(Editor.TextProperty, new Binding("Text", source: viewModel.Result.AssessmentQuestionInstructorNotes));

            //Button button = new Button
            //{
            //    Text = "Done",
            //    BackgroundColor = Color.Gray,
            //    FontSize = 12,
            //    AutomationId = "notesButton"
            //};
            //button.Clicked += Notes_Done_Clicked;

            //StackLayout layout = (StackLayout)Content;
            //layout.Children.Add(editor);
            //layout.Children.Add(button);

            //Content = layout;
            //await Navigation.PushAsync(new AssessmentQuestionNotes(viewModel.Result));
        }

        void Notes_Done_Clicked(object sender, EventArgs e)
        {
            //StackLayout layout = (StackLayout)Content;
            //IList<View> items = layout.Children;

            //Editor editor = (Editor)items.Where(x => x.AutomationId == "questionNotes").FirstOrDefault();
            //viewModel.Result.AssessmentQuestionInstructorNotes = editor.Text;
            //layout.Children.Remove(items.Where(x => x.AutomationId == "notesButton").FirstOrDefault());
            //layout.Children.Remove(editor);

            //Content = layout;
            viewModel.Result.AssessmentQuestionInstructorNotes = questionNotes.Text;
            btnNotesDone.IsEnabled = true;
            questionNotes.IsVisible = false;
            notesButton.IsVisible = false;
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
                await Navigation.PushAsync(new Results(), true);
                Navigation.RemovePage(this);
            }
        }

        public async void NavigateToNextQuestionViewAsync(Question question, AssessmentQuestion assessmentQuestion)
        {
            switch (question.Qtype)
            {
                case "5WayMC":
                    await Navigation.PushAsync(new FiveWayMCTemplate(new FiveWayMCTemplateViewModel(question, assessmentQuestion)));
                    Navigation.RemovePage(this);
                    break;
                case "3WayMC":
                    await Navigation.PushAsync(new ThreeWayMCTemplate(new ThreeWayMCTemplateViewModel(question, assessmentQuestion)));
                    Navigation.RemovePage(this);
                    break;
                case "2WayMC":
                    await Navigation.PushAsync(new TwoWayMCTemplate(new TwoWayMCTemplateViewModel(question, assessmentQuestion)));
                    Navigation.RemovePage(this);
                    break;
                case "SingleText":
                    await Navigation.PushAsync(new SingleTextTemplate(new SingleTextTemplateViewModel(question, assessmentQuestion)));
                    Navigation.RemovePage(this);
                    break;
                case "TripleText":
                    await Navigation.PushAsync(new TripleTextTemplate(new TripleTextTemplateViewModel(question, assessmentQuestion)));
                    Navigation.RemovePage(this);
                    break;
                default:
                    await Navigation.PushModalAsync(new AdminHome());
                    break;
            }
        }
    }
}