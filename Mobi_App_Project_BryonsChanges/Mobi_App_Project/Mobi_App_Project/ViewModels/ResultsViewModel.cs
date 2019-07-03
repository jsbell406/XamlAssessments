using Mobi_App_Project.Models;
using Mobi_App_Project.DB;
using Mobi_App_Project.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Windows.Input;
using System.Linq;


namespace Mobi_App_Project.ViewModels
{
    public class ResultsViewModel : BaseViewModel
    {
        public string MyEditor { get; set;}
        

        public ResultsViewModel()
        {
            
            MyEditor = App.ResultDB.SaveItemAsync().Result;
        }
    }
}
