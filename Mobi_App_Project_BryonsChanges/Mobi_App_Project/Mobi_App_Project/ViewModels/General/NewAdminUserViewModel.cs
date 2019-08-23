using Mobi_App_Project.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mobi_App_Project.ViewModels.General
{
    public class NewAdminUserViewModel : BaseViewModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public int Pin { get; set; }
        public AdminUser AdminUser { get; set; }

        public NewAdminUserViewModel()
        {
            AdminUser = new AdminUser();
        }
    }
}
