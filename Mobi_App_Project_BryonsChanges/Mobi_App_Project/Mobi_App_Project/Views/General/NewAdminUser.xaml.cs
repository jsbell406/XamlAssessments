using Mobi_App_Project.Helpers;
using Mobi_App_Project.ViewModels.General;
using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Mobi_App_Project.Views.General
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewAdminUser : ContentPage
    {
        NewAdminUserViewModel viewModel;
        bool isUserValid = false;
        bool isPassValid = false;
        bool isPinValid = false;
        bool isFormValid = false;
        string errorPin = "Pin needs to be 4 digits";
        string errorPass = "Password Must be at least 8 characters and must contain at least 1 symbol, capital letter, and number.";
        string errorUser = "Username must be between 5 and 30 characters.";
        
        public NewAdminUser()
        {
            InitializeComponent();
            viewModel = new NewAdminUserViewModel();
        }

        async void OnSubmitClicked(object sender, EventArgs e)
        {
            if(viewModel.IsBusy)
            {
                return;
            }
            viewModel.IsBusy = true;

            string userName = txtUserName.Text;
            string pass = txtPassword.Text;
            string pin = txtPin.Text;

            if (await ValidateFrom(pass,pin,userName))
            {                           
                string[] saltedHashPass = PasswordManagement.HashedPassAndSalt(pass,pin);
                viewModel.AdminUser.Hash = saltedHashPass[0];
                viewModel.AdminUser.Salt = saltedHashPass[1];
                viewModel.AdminUser.Pin = saltedHashPass[2];
                viewModel.AdminUser.DbName = userName;
                viewModel.AdminUser.UserName = userName;

                int isSaved = App.AdminUserDB.SaveItemAsync(viewModel.AdminUser).Result;

                if(viewModel.AdminUser.AdminUserId != 0)
                {
                    //save success
                    await DisplayAlert("Success", "User created successfully", "Done");
                    await Navigation.PushAsync(new Login());
                    Navigation.RemovePage(this);
                }
                else
                {
                    // Something went wrong
                    await DisplayAlert("Error", "Something went wrong please try again", "Done");
                    viewModel.IsBusy = false;
                    return;
                }               
            }
            else
            {
                // build error message
                if(!isPassValid & !isPinValid & !isUserValid )
                {
                    await DisplayAlert("Error", string.Format("1. {0}\n2. {1}\n3. {2}", errorUser, errorPass, errorPin), "Done");
                }
                else if(!isUserValid & !isPassValid)
                {
                    await DisplayAlert("Error", string.Format("1. {0}\n2. {1}", errorUser, errorPass), "Done");
                }
                else if(!isUserValid)
                {
                    await DisplayAlert("Error", string.Format("1. {0}", errorUser), "Done");
                }
                else if(!isUserValid & !isPinValid)
                {
                    await DisplayAlert("Error", string.Format("1. {0}\n2. {1}", errorUser, errorPin), "Done");
                }
                else if(!isPassValid & !isPinValid)
                {
                    await DisplayAlert("Error", string.Format("1. {0}\n2. {1}", errorUser, errorPin), "Done");
                }
                else if(!isPassValid)
                {
                    await DisplayAlert("Error", string.Format("1. {0}", errorPass), "Done");
                }
                else if(!isPinValid)
                {
                    await DisplayAlert("Error", string.Format("1. {0}", errorPin), "Done");
                }
                else
                {
                    await DisplayAlert("Error", "Failed to create user, try again.", "Done");
                }
            }          
            viewModel.IsBusy = false;
        }
        // Validate User Name: Must be atleast 5 characters long and less than 31 characters long(5-30) length.
        async void OnChangeUserNameVerify(object sender, EventArgs e)
        {
            string userName = txtUserName.Text;
            bool isUserValid = await VerifyUserName(userName);

            if(isUserValid)            
                UserNameFrame.BorderColor = Color.Green;           
            else           
                UserNameFrame.BorderColor = Color.Red;            
        }
  
        async void OnChangePasswordVerify(object sender, EventArgs e)
        {
            string password = txtPassword.Text;
            bool isPassValid = await VerifyPassword(password);

            if (isPassValid)
                PasswordFrame.BorderColor = Color.Green;
            else
                PasswordFrame.BorderColor = Color.Red;
        }

        async void OnChangePinVerify(object sender, EventArgs e)
        {
            string strPin = txtPin.Text;
            bool isPinValid = await VerifyPin(strPin);

            if (isPinValid)
                PinFrame.BorderColor = Color.Green;
            else
                PinFrame.BorderColor = Color.Red;
        }

        private async Task<bool> ValidateFrom(string pass, string pin, string user)
        {
            await Task.Run(() => {
                bool isPass = VerifyPassword(pass).Result;
                bool isPin = VerifyPin(pin).Result;
                bool isUser = VerifyUserName(user).Result;
                if (isPass & isPin & isUser)
                    isFormValid = true;
                else
                    isFormValid = false;
            });
            return isFormValid;
        }

        private async Task<bool> VerifyPassword(string password)
        {
            await Task.Run(() =>
            {
                // Password must have a number a upper case char and at least 8 characters long
                var hasNumber = new Regex(@"[0-9]+");
                var hasUpperChar = new Regex(@"[A-Z]+");
                var hasMinimum8Chars = new Regex(@".{8,}");

                bool isUpper = false;
                bool isEight = false;
                bool isNumber = false;

                if (hasNumber.IsMatch(password) & hasUpperChar.IsMatch(password) & hasMinimum8Chars.IsMatch(password))
                {
                    // Acceptable password
                    isPassValid = true;
                    isUpper = true;
                    isEight = true;
                    isNumber = true;
                    viewModel.Password = password;                                          
                }
                else
                {
                    if (hasNumber.IsMatch(password))
                        isNumber = true;
                    else
                        isNumber = false;

                    if (hasMinimum8Chars.IsMatch(password))
                        isEight = true;
                    else
                        isEight = false;

                    if (hasUpperChar.IsMatch(password))
                        isUpper = true;
                    else
                        isUpper = false;
                }
            });
            return isPassValid;
        }

        private async Task<bool> VerifyUserName(string userName)
        {
            await Task.Run(() =>
            {
                if (txtUserName.Text.Length > 4 & txtUserName.Text.Length < 31)
                {
                    // Valid
                    viewModel.UserName = txtUserName.Text;
                    isUserValid = true;
                }
                else
                {
                    // no good
                    isUserValid = false;
                }
            });
            return isUserValid;
        }

        private async Task<bool> VerifyPin(string strPin)
        {
            bool isDigits = false;
            bool isFour = false;
            isPinValid = false;

            await Task.Run(() =>
            {
                
                if (strPin.Length == 4)
                {
                    if (int.TryParse(strPin, out int pin))
                    {
                        // pin is 4-digit
                        isPinValid = true;
                        isDigits = true;
                        isFour = true;
                        viewModel.Pin = pin;
                    }
                    else
                    {
                        // pin is not a number
                        isDigits = false;
                        isPinValid = false;
                    }
                }
                else
                {
                    // pin not 4-digit not good                                         
                    isFour = false;
                    isPinValid = false;
                }             
            });
            return isPinValid;
        }      
    }
}