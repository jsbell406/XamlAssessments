using Mobi_App_Project.Models;
using Mobi_App_Project.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Mobi_App_Project.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AssessmentSelection : ContentPage
	{
        AssessmentSelectionViewModel viewModel;

		public AssessmentSelection()
		{
			InitializeComponent ();
            BindingContext = viewModel = new AssessmentSelectionViewModel();
		}

        async void OnAssessmentSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var assessment = args.SelectedItem as Assessment;
            if (assessment == null)
                return;
           
            App.Assessment = assessment;
            viewModel.Assessment = assessment;

            viewModel.LoadAssessmentQuestions();

            await Navigation.PushAsync(new AssessmentHome(viewModel));

            AssessmentListView.SelectedItem = null;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            viewModel.LoadAssessmentsCommand.Execute(true);
        }
    }
}