using System;
using System.Collections.Generic;
using System.Text;
using Mobi_App_Project.Models;
using System.Linq;
using Mobi_App_Project.DB;

namespace Mobi_App_Project.ViewModels
{
    public class LoginViewModel : ObservableObject
    {
        private IList<AdminUser> adminUsers;
        private string userName;
        private string passWord;
        private string message;

        public string UserName { get => userName; set => SetProperty(ref userName, value); }
        public string PassWord { get => passWord; set => SetProperty(ref passWord, value); }
        public string Message { get => message; set => SetProperty(ref message, value); }

        //public string UserName { get; set; }
        //public string PassWord { get; set; }
        //public string Message { get; set; }

        private async void init()
        {
            try
            {
                AdminUserDB userDB = App.AdminUserDB;
                // adminUsers = new List<AdminUser>();
                //adminUsers.Add(await userDB.GetItemAsync(1));
                adminUsers = await userDB.GetItemsAsync();
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }
        }
        public LoginViewModel()
        {
            init();
        }
        public bool UserAuthenticated()
        {
            if (adminUsers != null && adminUsers.Count > 0)
            {
                int count = adminUsers.Count;
                AdminUser user = adminUsers.Where(u => u.UserName == UserName).FirstOrDefault();
                if (user != null)
                {

                    if (user.Hash == PassWord)
                    {
                        App.AdminUser = user;
                        return true;
                        //await Navigation.PushAsync(new AdminHome());
                        //message = "Good Login";
                    }
                    else
                    {
                        Message = "Invald Login";
                        //await Navigation.PushAsync(new AdminHome());
                    }
                }
                else
                {
                    Message = "Invald Login";

                }
                //passWord = message;
            }
            else
            {
                Message = "No users found.";
            }
            return false;
        }
    }
}
