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
	public partial class StudentEntry : ContentPage
	{
        private string groupName = "";
        private string individualName = "";
      


        async void Save_Clicked(object sender, EventArgs e)
        {
            //MessagingCenter.Send(this, "AddItem", Item);
            await Navigation.PopModalAsync();
        }

        async void Submit_Clicked(object sender, EventArgs e)
        {
            //MessagingCenter.Send(this, "AddItem", Item);
           // await Navigation.PopModalAsync();
            //await Navigation.PushAsync(new Question1());
        }

        public StudentEntry ()
		{
			InitializeComponent ();
		}
	}
}