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
	public partial class Question9 : ContentPage
	{
		public Question9 ()
		{
			InitializeComponent ();
		}
        async void Submit_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AdminHome());
        }
    }
}