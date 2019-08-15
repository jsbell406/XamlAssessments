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
	public partial class NewAdminUser : ContentPage
	{
		public NewAdminUser ()
		{
			InitializeComponent ();
		}

        async void OnSubmitClicked(object sender, EventArgs e)
        {
            await DisplayAlert("Success", "User created successfully", "Done");
            await Navigation.PushAsync(new Login());
            Navigation.RemovePage(this);
        }
    }
}