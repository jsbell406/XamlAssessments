using Mobi_App_Project.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mobi_App_Project.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Collections.ObjectModel;

namespace Mobi_App_Project.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class IndividualStudentSelection : ContentPage
	{
        public IndividualStudentSelectionViewModel viewModel;

        public IndividualStudentSelection()
		{          
            InitializeComponent();          
            BindingContext = viewModel = new IndividualStudentSelectionViewModel();     
        }
        private async void SelectedStudent(object sender, EventArgs e)
        {
            // Nav to assessment selection
            await Navigation.PushAsync(new NavigationPage(new AssessmentSelection()));         
        }

        async void Create_Clicked(object sender, EventArgs e)
        { 
           await Navigation.PushAsync(new NavigationPage(new NewStudentForm()));
        }     
    }
}