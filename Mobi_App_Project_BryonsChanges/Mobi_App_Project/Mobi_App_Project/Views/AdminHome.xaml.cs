using Mobi_App_Project.Models;
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
	public partial class AdminHome : ContentPage
	{
		public AdminHome ()
		{
			InitializeComponent ();
            BindingContext = this;
		}
        async void Group_Clicked(object sender, EventArgs e)
        {
            //check login MessagingCenter.Send(this, "AddItem", Item);
            App.IsGroup = true;
            await Navigation.PushAsync(new StudentEntry());
        }

        async void Individual_Clicked(object sender, EventArgs e)
        {
            App.IsGroup = false;
            await Navigation.PushAsync(new IndividualStudentSelection());
        }

        async void Record_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Record());
        }     
    }
}