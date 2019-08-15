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
	public partial class AssessmentQuestionNotes : ContentPage
	{
        AssessmentQuestionNotesViewModel viewModel;

		public AssessmentQuestionNotes (Result result)
		{
			InitializeComponent ();
            BindingContext = viewModel = new AssessmentQuestionNotesViewModel(result);            
		}

        async void Done_Clicked(object sender, EventArgs e)
        {
            await App.ResultDB.SaveItemAsync(viewModel.Result);
            await Navigation.PopAsync(true);
        }
        void OnEditorCompleted(object sender, EventArgs e)
        {
           // viewModel.Result.AssessmentQuestionInstructorNotes = ((Editor)sender).Text;
        }
    }
}