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
	public partial class IndividualStudentSelection : ContentPage
	{
		public IndividualStudentSelection()
		{
            InitializeComponent();
            bool check = true;
            IndividualStudentSelectionViewModel view = new IndividualStudentSelectionViewModel();
            this.BindingContext = view;

        }
    }
}