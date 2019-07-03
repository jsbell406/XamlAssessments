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
	public partial class SingleTextTemplate : ContentPage
	{
        SingleTextTemplateViewModel viewModel;

		public SingleTextTemplate ()
		{
			InitializeComponent ();
            //BindingContext = viewModel = new SingleTextTemplateViewModel();
		}

        public SingleTextTemplate(SingleTextTemplateViewModel vm)
        {
            InitializeComponent();
            BindingContext = viewModel = vm;
        }
    }
}