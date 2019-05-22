using Mobi_App_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mobi_App_Project.DB;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Mobi_App_Project.ViewModels;

namespace Mobi_App_Project.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AdminLogin : ContentPage
	{
        //private string userName = "";
        //private string passWord = "";
        //public Item Item { get; set; }
        private string message = "";
        //private IList<AdminUser> adminUsers;
        private LoginViewModel vm;

        public AdminLogin (LoginViewModel vmod)
		{
            vm = vmod;

            //var vm = BindingContext as LoginViewModel;
            //AdminUserDB userDB = App.AdminUserDB;
            //vm.AdminUsers = await userDB.GetItemsAsync();
            BindingContext = vm;
            //message = "starting";
            //userName = "a";
            //passWord = "b";
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            // Reset the 'resume' id, since we just want to re-start here
            // ((App)App.Current).ResumeAtTodoId = -1;
            //            listView.ItemsSource = tivm.Items; //await App.Database.GetItemsAsync();
            //try
            //{
            //    AdminUserDB userDB = App.AdminUserDB;
            //   // adminUsers = new List<AdminUser>();
            //    //adminUsers.Add(await userDB.GetItemAsync(1));
            //    adminUsers = await userDB.GetItemsAsync();
            //}
            //catch(Exception ex)
            //{
            //    string msg = ex.Message;
            //    int i = 0;
            //}

            

        }

        async void Login_Clicked(object sender, EventArgs e)
        {

            //this.passWord = "started";
           // await Navigation.PushAsync(new AdminHome());
            try
            {
                var lvm = BindingContext as LoginViewModel;
                //BindingContext = this;

                if(lvm.UserAuthenticated())
                {
                    await Navigation.PushAsync(new AdminHome());
                }
                else
                {
                    InitializeComponent();
                }


                
                //if (adminUsers != null && adminUsers.Count > 0)
                //{
                //    int count = adminUsers.Count;
                //    //string username = adminUsers.First().UserName;
                //    AdminUser user = adminUsers.Where(u => u.UserName == bindingContext.userName).FirstOrDefault();
                //    if (user != null)
                //    {

                //        if (user.PasswordHash == bindingContext.passWord)
                //        {
                //            App.AdminUser = user;
                //            await Navigation.PushAsync(new AdminHome());
                //            //message = "Good Login";

                //        }
                //        else
                //        {
                //            message = "Invald Login";
                //            //await Navigation.PushAsync(new AdminHome());

                //        }
                //    }
                //    else
                //    {
                //        message = "Invald Login";
                        
                //    }
                //    passWord = message;
                //}
                //else
                //{
                //    message = "No users found.";
                //}
                //check login MessagingCenter.Send(this, "AddItem", Item);
                // AdminUserDB userDB = App.AdminUserDB;
                //AdminUsers = await userDB.GetItemsAsync();
                //AdminUser user = users.Where(u => u.UserName == userName).FirstOrDefault();
                //if(user != null)
                //{
                //   if( user.PasswordHash == passWord)
                //    {
                //        App.AdminUser = user;
                //        await Navigation.PushAsync(new AdminHome());
                //    }
                //    else
                //    {
                //        message = "Invald Login";
                //    }
                //}
                //else
                //{
                //    message = "Invald Login";
                //}
            }
            catch(Exception ex)
            {
                message = ex.Message;
                //passWord = message;
            }
           // await Navigation.PushAsync(new AdminHome());

        }

        
    
	}
}