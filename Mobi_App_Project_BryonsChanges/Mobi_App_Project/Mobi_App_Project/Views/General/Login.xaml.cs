using Mobi_App_Project.Helpers;
using Mobi_App_Project.Models;
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
        AdminUser admin = null;
        bool isBusy = false;
		public Login ()
		{
			InitializeComponent ();
            App.AdminUser = null;
		}

        async void OnLoginClicked(object sender, EventArgs e)
        {
            if(isBusy)
            {
                return;
            }
            isBusy = true;

            string userName = txtLogin.Text;
            string password = txtPassword.Text;

            try
            {
                admin = await App.AdminUserDB.GetUserByUsername(userName);
                if (admin == null)
                {
                    await DisplayAlert("Login Error", "Username does not exist", "Done");
                    isBusy = false;
                    return;
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Login Error", "Something went wrong please try again", "Done");
                isBusy = false;
                return;
            }

            if(PasswordManagement.LoginPasswordVerifier(password,admin.Hash, admin.Salt))
            {
                TabbedPage adminHome = new TabbedPage();
                adminHome.Children.Add(new Students());
                adminHome.Children.Add(new Assessments());
                adminHome.Children.Add(new Records());
                App.AdminUser = admin;

                await Navigation.PushModalAsync(adminHome, true);
                txtLogin.Text = "";
                txtPassword.Text = "";
            }
            else
            {
                await DisplayAlert("Login Failed", "Failed Attempt", "Done");
            }
            isBusy = false;
        }       
        
        protected override void OnAppearing()
        {
            txtLogin.Text = "";
            txtPassword.Text = "";
            App.AdminUser = null;
        }
    }
}