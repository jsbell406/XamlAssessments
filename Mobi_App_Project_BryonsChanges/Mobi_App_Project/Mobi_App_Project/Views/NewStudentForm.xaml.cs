using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mobi_App_Project.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Mobi_App_Project.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class NewStudentForm : ContentPage
	{
        public Student Student { get; set; }

		public NewStudentForm()
		{
			InitializeComponent ();

            Student = new Student
            {
                FirstName = "First Name",
                LastName = "Last Name",
                MiddleName = "Middle Name",
                Age = 00,
                Grade = "Grade"
            };

            BindingContext = this;
		}

        async void Submit_Clicked(object sender, EventArgs e)
        {
            await App.StudentDB.SaveItemAsync(Student);
            await Navigation.PushModalAsync(new AssessmentHome());
        }

    }
}