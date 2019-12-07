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
	public partial class TwoWayMCTemplate : ContentPage
	{
        TwoWayMCTemplateViewModel viewModel;

		public TwoWayMCTemplate ()
		{
			InitializeComponent ();
		}
        public TwoWayMCTemplate(TwoWayMCTemplateViewModel vm)
        {
            InitializeComponent();
            BindingContext = viewModel = vm;
        }
        
       

        void Submit_Opt1_Clicked(object sender, EventArgs e)
        {
            HandleResult(viewModel.Opt1);
        }

        void Submit_Opt2_Clicked(object sender, EventArgs e)
        {
            HandleResult(viewModel.Opt2);
        }

        private async void HandleResult(string result)
        {
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
        async void Notes_Clicked(object sender, EventArgs e)
        {
            btnNotesDone.IsEnabled = false;
            AbsoluteLayout layout = (AbsoluteLayout)Content;

            Editor editor = new Editor
            {
                AutomationId = "questionNotes",
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            editor.SetBinding(Editor.TextProperty, new Binding("Text", source: viewModel.Result.AssessmentQuestionInstructorNotes));
            AbsoluteLayout.SetLayoutBounds(editor, new Rectangle(100, 500, .2, 75));
            AbsoluteLayout.SetLayoutFlags(editor, AbsoluteLayoutFlags.WidthProportional);
            editor.BackgroundColor = Color.FromHex("#A4EAFF");


            Button button = new Button
            {
                Text = "Done",
                BackgroundColor = Color.Gray,
                FontSize = 12,
                AutomationId = "notesButton"
            };

            button.Clicked += Notes_Done_Clicked;
            AbsoluteLayout.SetLayoutBounds(button, new Rectangle(0, 300, .2, 75));
            AbsoluteLayout.SetLayoutFlags(button, AbsoluteLayoutFlags.WidthProportional);
            button.Clicked += Notes_Done_Clicked;


            layout.Children.Add(editor);
            layout.Children.Add(button);

            Content = layout;
            //await Navigation.PushAsync(new AssessmentQuestionNotes(viewModel.Result));
        }

        void Notes_Done_Clicked(object sender, EventArgs e)
        {
            AbsoluteLayout layout = (AbsoluteLayout)Content;
            IList<View> items = layout.Children;

            Editor editor = (Editor)items.Where(x => x.AutomationId == "questionNotes").FirstOrDefault();
            viewModel.Result.AssessmentQuestionInstructorNotes = editor.Text;
            layout.Children.Remove(items.Where(x => x.AutomationId == "notesButton").FirstOrDefault());
            layout.Children.Remove(editor);

            Content = layout;
            btnNotesDone.IsEnabled = true;
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