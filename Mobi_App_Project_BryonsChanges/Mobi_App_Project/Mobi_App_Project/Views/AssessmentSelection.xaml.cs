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

            // TODO: verify assessment gets set in app
            App.Assessment = assessment;
            await Navigation.PushAsync(new NavigationPage(new AssessmentHome()));

            AssessmentListView.SelectedItem = null;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            viewModel.LoadAssessmentsCommand.Execute(true);
        }
    }
}