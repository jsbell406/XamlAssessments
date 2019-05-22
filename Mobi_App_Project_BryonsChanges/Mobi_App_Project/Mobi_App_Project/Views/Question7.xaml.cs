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
	public partial class Question7 : ContentPage
	{
		public Question7 ()
		{
			InitializeComponent ();
		}
        async void Submit_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Question8());
        }
    }
}