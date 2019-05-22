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
	public partial class IndividualStudentSelection : ContentPage
	{
        public Student Student { get; set; }

		public IndividualStudentSelection ()
		{
			InitializeComponent ();

            Student = new Student
            {
                FirstName = "First Name",
                LastName = "Last Name",
                MiddleName = "Middle Name",
                Age = 00,
                Grade = 0
            };

		}
	}
}