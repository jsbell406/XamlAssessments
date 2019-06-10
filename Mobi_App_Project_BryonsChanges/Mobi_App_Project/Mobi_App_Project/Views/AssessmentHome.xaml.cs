using Mobi_App_Project.Models;
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
	public partial class AssessmentHome : ContentPage
	{
		public AssessmentHome ()
		{
			InitializeComponent ();
            Assessment assessment = new Assessment();
            assessment.AssessName = App.Assessment.AssessName;
            Title = "Assessment Title";
            BindingContext = assessment;
          
		}

        async void Start_Clicked(object sender, EventArgs e)
        {
            //QuestionViewModel qvm = new QuestionViewModel(studentId, 1, assessmentId);


           // await Navigation.PushAsync(new Question1());
        }
    }
}