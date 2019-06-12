using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Mobi_App_Project.ViewModels;
using Mobi_App_Project.Models;

namespace Mobi_App_Project.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Question1 : ContentPage
	{
        QuestionViewModel viewModel;
		public Question1 ()
		{
			InitializeComponent ();
            BindingContext = viewModel = new QuestionViewModel();
        }

        public Question1(QuestionViewModel viewModel)
        {
            BindingContext = this.viewModel = viewModel;
        }

        //public IEnumerable<CarouselPage> Question { get; private set; }

       

        async void Submit_Clicked(object sender, EventArgs e)
        {
            Result result = new Result();
            result.TextResults = "Happy";
            await Navigation.PushAsync(new Question2());
        }
      
    }
}