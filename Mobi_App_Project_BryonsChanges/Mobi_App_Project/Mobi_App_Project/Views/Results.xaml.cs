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
            var MyEditor = new Editor { Text = "I am an Editor", AutoSize = EditorAutoSizeOption.TextChanges};
            //var text = MyEditor.Text;
           //Editor textEntry = MyEditor;
            BindingContext = viewModel = new ResultsViewModel();
            InitializeComponent();
        }

        public Result MyEditor { get; private set; }

        async void Submit_Clicked(object sender, EventArgs e)
        {
            await App.ResultDB.SaveItemAsync(MyEditor);
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
    }
}