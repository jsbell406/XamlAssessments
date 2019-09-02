using Mobi_App_Project.Models;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Mobi_App_Project.Views.Create
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class StudentCreate : ContentPage
	{
        public Student Student { get; set; }

        public StudentCreate ()
		{
			InitializeComponent();
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

        async void Back_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

        /// <summary>
        /// Takes Student Returns True is student was saved
        /// </summary>
        /// <param name="studentToSave"></param>
        /// <returns></returns>
        private async Task<bool> SaveStudent (Student studentToSave)
        {
            bool isSuccess = false;
            await Task.Run(async () => {
                int successTask = await App.StudentDB.SaveItemAsync(studentToSave);
                if(successTask == 1)
                {
                    App.Student = Student;
                    isSuccess = true;
                }
                else
                {
                    isSuccess = false;
                }
            });
            return isSuccess;
        }
       
        async void Submit_Clicked(object sender, EventArgs e)
        {           
            try
            {

                bool isUni = await IsStudentUnique(Student);
                if (isUni)
                {
                    bool isSaved = await SaveStudent(Student);

                    if (isSaved)
                    {
                        bool isAnotherStudent = await DisplayAlert("Student Saved", "Would you like to enter another student?", "Yes", "No");
                        if (isAnotherStudent)
                        {
                            Student.StudentId = 0;
                            Student.Grade = "";
                            Student.FirstName = "";
                            Student.LastName = "";
                            Student.Age = 00;

                            txtFirstName.Text = "";
                            txtLastName.Text = "";
                            txtMiddleName.Text = "";
                            txtGrade.Text = "";
                        }
                        else
                        {
                            await Navigation.PopModalAsync(true);
                        }
                    }
                    else
                    {
                        await DisplayAlert("Error", "Failed to save student, Please try again.", "Done");
                    }                   
                }
                else
                {
                    bool saveAnyway = await DisplayAlert("Duplicate Found", string.Format("{0} already exists in the database. Would you like to save anyway?", Student.ToString()), "Yes", "No");
                    if(saveAnyway)
                    {
                        if (await SaveStudent(Student))
                        {
                            bool isAnotherStudent = await DisplayAlert("Student Saved", "Would you like to enter another student?", "Yes", "No");
                            if (isAnotherStudent)
                            {
                                Student.StudentId = 0;
                                Student.Grade = "";
                                Student.FirstName = "";
                                Student.LastName = "";
                                Student.Age = 00;

                                txtFirstName.Text = "";
                                txtLastName.Text = "";
                                txtMiddleName.Text = "";
                                txtGrade.Text = "";
                            }
                            else
                            {
                                await Navigation.PopModalAsync(true);
                            }
                        }
                        else
                        {
                            await DisplayAlert("Error", "Failed to save student, Please try again.", "Done");
                        }
                    }
                }               
            }
            catch(Exception ex)
            {
               // await Console.Error.WriteLineAsync(ex.Message);
                await DisplayAlert("Error", string.Format("Error Connecting to Database, Please try again.\n{0}",ex.Message), "Done");
                return;
            }           
        }

        private async Task<bool> IsStudentUnique(Student studentToVerify)
        {
            bool isStudentUnique = false;
            Student student = null;

            await Task.Run(async () =>
            {
                try
                {
                    if (studentToVerify.MiddleName.Length == 0)
                    {
                        student = await App.StudentDB.GetStudentByName(studentToVerify.FirstName, studentToVerify.LastName);
                    }
                    else if (studentToVerify.MiddleName.Length > 0)
                    {
                        student = await App.StudentDB.GetStudentByName(studentToVerify.FirstName, studentToVerify.MiddleName, studentToVerify.LastName);
                    }
                }
                catch(Exception ex)
                {
                    isStudentUnique = false;                   
                }

                if(student != null)
                {
                    if (student.Equals(studentToVerify))
                    {
                        //not unique
                        isStudentUnique = false;
                    }
                    else
                    {
                        isStudentUnique = true;
                    }
                }
                else
                {
                    isStudentUnique = true;
                }

                
            });
           return isStudentUnique;
        }
    }
}