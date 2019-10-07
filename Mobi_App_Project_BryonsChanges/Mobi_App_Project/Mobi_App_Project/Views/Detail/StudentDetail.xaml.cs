using Mobi_App_Project.Models;
using Mobi_App_Project.ViewModels;
using Mobi_App_Project.ViewModels.Detail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Mobi_App_Project.Views.Detail
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class StudentDetail : ContentPage
	{      
        private bool isBusy;       
        public StudentDetailViewModel viewModel;
 
        public StudentDetail(StudentDetailViewModel vm)
        {
            InitializeComponent();
            isBusy = false;

            BindingContext = viewModel = vm;
        }
        async void OnChangeFirstName(object sender, EventArgs eventArgs)
        {
            bool isValid = await ValidateFirstName();
            if (isValid)
                FirstNameFrame.BorderColor = Color.Green;
            else
                FirstNameFrame.BorderColor = Color.Red;
        }

        async void OnEntryComplete(object sender, EventArgs eventArgs)
        {
            bool isFormValid = false;
            isFormValid = await ValidateForm();
            if (isFormValid)
            {
                SubmitButtonFrame.BorderColor = Color.Green;
                btnSubmit.BackgroundColor = Color.Green;
            }
            else
            {
                SubmitButtonFrame.BorderColor = Color.Red;
                btnSubmit.BackgroundColor = Color.Red;
            }
        }

        async void OnChangeLastName(object sender, EventArgs eventArgs)
        {
            bool isValid = await ValidateLastName();
            if (isValid)
                LastNameFrame.BorderColor = Color.Green;
            else
                LastNameFrame.BorderColor = Color.Red;
        }

        // Currently only constraint is the first name must be more than zero characters long
        private async Task<bool> ValidateFirstName()
        {
            bool isValid = false;

            await Task.Run(() =>
            {
                // validate First Name Logic
                string fName = "";
                fName = txtFirstName.Text;
                if (fName != null)
                {
                    if (fName.Length > 0)
                        isValid = true;
                }
            });
            return isValid;
        }

        private async Task<bool> ValidateLastName()
        {
            bool isValid = false;

            await Task.Run(() =>
            {
                // validate Last Name Logic
                string lName = "";
                lName = txtLastName.Text;
                if (lName != null)
                {
                    if (lName.Length > 0)
                        isValid = true;
                }

            });
            return isValid;
        }

        private async Task<bool> ValidateForm()
        {
            bool isValid = false;

            await Task.Run(async () =>
            {
                bool isFirstNameValid = await ValidateFirstName();
                bool isLastNameValid = await ValidateLastName();
                if (isFirstNameValid & isLastNameValid)
                    isValid = true;
            });
            return isValid;
        }

        async void Back_Clicked(object sender, EventArgs e)
        {  
            await Navigation.PopModalAsync();
        }
  
        private async Task<bool> SaveStudent(Student studentToSave)
        {
            bool isSuccess = false;
            await Task.Run(async () => {
                int successTask = await App.StudentDB.SaveItemAsync(studentToSave);
                if (successTask == 1)
                {
                    App.Student = viewModel.Student;
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
                bool isValid = await ValidateForm();
                if (isValid)
                {
                    bool isUni = await IsStudentUnique(viewModel.Student);
                    if (isUni)
                    {
                        bool isSaved = await SaveStudent(viewModel.Student);

                        if (isSaved)
                        {
                            bool isAnotherStudent = await DisplayAlert("Student Saved", "Would you like to enter another student?", "Yes", "No");
                            if (isAnotherStudent)
                            {
                                viewModel.Student.StudentId = 0;
                                viewModel.Student.Grade = "";
                                viewModel.Student.FirstName = "";
                                viewModel.Student.LastName = "";
                                viewModel.Student.Age = 00;

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
                        bool saveAnyway = await DisplayAlert("Duplicate Found", string.Format("{0} already exists in the database. Would you like to save anyway?", viewModel.Student.ToString()), "Yes", "No");
                        if (saveAnyway)
                        {
                            if (await SaveStudent(viewModel.Student))
                            {
                                bool isAnotherStudent = await DisplayAlert("Student Saved", "Would you like to enter another student?", "Yes", "No");
                                if (isAnotherStudent)
                                {
                                    viewModel.Student.StudentId = 0;
                                    viewModel.Student.Grade = "";
                                    viewModel.Student.FirstName = "";
                                    viewModel.Student.LastName = "";
                                    viewModel.Student.Age = 00;

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
                else
                {
                    //form is not valid need to build alert message telling them whats required
                    await DisplayAlert("Required Fields not filled", "First and last Name are required, other fields are optional", "Done");
                }

            }
            catch (Exception ex)
            {
                // await Console.Error.WriteLineAsync(ex.Message);
                await DisplayAlert("Error", string.Format("Error Connecting to Database, Please try again.\n{0}", ex.Message), "Done");
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
                catch (Exception ex)
                {
                    isStudentUnique = false;
                }

                if (student != null)
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

        async void OnDeletePressed(object sender, EventArgs e)
        {
            if(isBusy)
            {
                return;
            }
            isBusy = true;
            // display popup verify 
            bool isDelete = await DisplayAlert("Confirm", "Permanently delete student record?", "Yes", "No");
            if(isDelete)
            {
                int intSuccess = await App.StudentDB.DeleteItemAsync(viewModel.Student);
                if(intSuccess == 1)
                {
                    await DisplayAlert("Success", "Student recorded deleted", "Done");
                    await Navigation.PopModalAsync();
                    isBusy = false;
                }
                else
                {
                    await DisplayAlert("Error", "Something went wrong. Please try again.", "Done");
                    isBusy = false;
                    return;
                }
            }
            isBusy = false;
        }

        async void OnAssessmentPressed(object sender,EventArgs e)
        {
            if(isBusy)
            {
                return;
            }
            isBusy = true;

            viewModel.Assessments.Clear();
            viewModel.Assessments = await App.AssesmentDB.GetAssessmentDictionary();
            viewModel.AssessmentsList.Clear();
            foreach(KeyValuePair<string,Assessment> valuePair in viewModel.Assessments)
            {
                viewModel.AssessmentsList.Add(valuePair.Key);
            }

            //pkrAssessment.IsVisible = true;
            pkrAssessment.Focus();
            isBusy = false;
        }

        async void OnAssessmentSelected(object sender, SelectedItemChangedEventArgs args)
        {
            if (isBusy)
                return;

            isBusy = true;
            if(!viewModel.Assessments.TryGetValue(pkrAssessment.SelectedItem.ToString(),out Assessment selectedAssessment))        
                return;
            
            App.Student = viewModel.Student;
            App.Assessment = selectedAssessment;

            // nav to assessment
            AssessmentSelectionViewModel vm = new AssessmentSelectionViewModel();
            vm.Assessment = selectedAssessment;
            vm.LoadAssessmentQuestions();
            NavigationPage page = new NavigationPage(new AssessmentHome(vm));


            Navigation.PopModalAsync();

            await Navigation.PushModalAsync(page);
            

            isBusy = false;
        }

        async void OnEditPressed(object sender, EventArgs e)
        {
            // enable all text boxes

            // reveal save button

            // On save run standard validation 

            // On success reset page with updated information
        }
    }
}