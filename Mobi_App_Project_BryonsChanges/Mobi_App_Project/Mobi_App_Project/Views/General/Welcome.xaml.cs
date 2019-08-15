using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Mobi_App_Project.Views.General
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Welcome : ContentPage
	{
		public Welcome ()
		{
			InitializeComponent ();
		}
        async void OnButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NewAdminUser());
            Navigation.RemovePage(this);
        }
    }
}