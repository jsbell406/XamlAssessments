using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mobi_App_Project.Models;
using Mobi_App_Project.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Mobi_App_Project.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Results : ContentPage
    {
        private ResultsViewModel viewModel;

        public Results()
        {
          
            BindingContext = viewModel = new ResultsViewModel();
            InitializeComponent();
            
        }

        public AssessmentSession AdminNotes { get; private set; }

        private async void SelectedResult(object sender, EventArgs e)
        {
            
            
        }

        async void Submit_Clicked(object sender, EventArgs e)
        {
            AdminNotes = new AssessmentSession();
            App.AssessmentSession.AdminNotes = viewModel.MyEditor;
            //AdminNotes. = viewModel.MyEditor;
            await App.AssesmentSessionDB.SaveItemAsync(App.AssessmentSession);
            if (App.IsGroup)
            {
                await Navigation.PushModalAsync(new NavigationPage(new AssessmentHome()));
            }
            else
            {
                await Navigation.PushModalAsync(new NavigationPage(new AdminHome()));
            }
            //await Navigation.PushModalAsync(new NavigationPage(new AssessmentSelection()));
        }

        internal Task GetItemsAsync()
        {
            throw new NotImplementedException();
        }
    }
}