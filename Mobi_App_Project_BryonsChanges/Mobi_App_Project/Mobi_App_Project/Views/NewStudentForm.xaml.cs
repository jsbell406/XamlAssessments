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
                FirstName = "",
                LastName = "",
                MiddleName = "",
                Age = 00,
                Grade = ""
            };

            BindingContext = Student;
		}

        async void Submit_Clicked(object sender, EventArgs e)
        {
            Task<int> successTask = App.StudentDB.SaveItemAsync(Student);
            int success = successTask.Result;
            if(success == 1)
            {
                await Navigation.PopAsync(true);
            }
            return;           
        }
    }
}