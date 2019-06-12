using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mobi_App_Project.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Mobi_App_Project.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Record : ContentPage
    {
        public RecordViewModel viewModel;

        public Record()
        {
            InitializeComponent();
            BindingContext = viewModel = new RecordViewModel();
        }
        private async void SelectedDate(object sender, EventArgs e)
        {
            // Nav to assessment selection
            //await Navigation.PushAsync(new NavigationPage(new AssessmentSelection()));         
        }

        private async void SelectedStudent(object sender, EventArgs e)
        {
            // Nav to assessment selection
            //await Navigation.PushAsync(new NavigationPage(new AssessmentSelection()));         
        }
    }
	
}