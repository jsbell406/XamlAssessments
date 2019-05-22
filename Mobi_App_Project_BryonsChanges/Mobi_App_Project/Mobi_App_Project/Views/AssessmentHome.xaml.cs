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
		}

        async void Start_Clicked(object sender, EventArgs e)
        {
            int studentId = 1; // from selection;
            int assessmentId = 1;  // only have one now
            QuestionViewModel qvm = new QuestionViewModel(studentId, 1, assessmentId);


            await Navigation.PushAsync(new Question1());
        }
    }
}