using Mobi_App_Project.ViewModels;
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
	public partial class FiveWayMCTemplate : ContentPage
	{
        FiveWayMCTemplateViewModel viewModel;

		public FiveWayMCTemplate ()
		{
			InitializeComponent ();
            
		}
        public FiveWayMCTemplate(FiveWayMCTemplateViewModel vm)
        {
            InitializeComponent();
            BindingContext = viewModel = vm;
        }

        async void Submit_Opt1_Clicked(object sender, EventArgs e)
        {
            
        }

        async void Submit_Opt2_Clicked(object sender, EventArgs e)
        {

        }

        async void Submit_Opt3_Clicked(object sender, EventArgs e)
        {

        }

        async void Submit_Opt4_Clicked(object sender, EventArgs e)
        {

        }

        async void Submit_Opt5_Clicked(object sender, EventArgs e)
        {

        }
    }
}