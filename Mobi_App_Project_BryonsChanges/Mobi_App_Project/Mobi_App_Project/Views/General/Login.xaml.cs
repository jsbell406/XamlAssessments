using Mobi_App_Project.Views.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Mobi_App_Project.Views.General
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Login : ContentPage
	{
		public Login ()
		{
			InitializeComponent ();
		}

        async void OnLoginClicked(object sender, EventArgs e)
        {
            //await DisplayAlert("Login Failed", "User name or password incorrect", "Done");

            TabbedPage adminHome = new TabbedPage();
            adminHome.Children.Add(new Students());
            adminHome.Children.Add(new Assessments());
            adminHome.Children.Add(new Records());
        
            await Navigation.PushModalAsync(adminHome, true);           
        }
    }
}