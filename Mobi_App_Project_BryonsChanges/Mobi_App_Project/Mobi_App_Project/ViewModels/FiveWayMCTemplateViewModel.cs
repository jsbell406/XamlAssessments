using Mobi_App_Project.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mobi_App_Project.ViewModels
{
    public class FiveWayMCTemplateViewModel : BaseViewModel
    {
        public Question Question { get; set; }
        public string Opt1 { get; set; }
        public string Opt2 { get; set; }
        public string Opt3 { get; set; }
        public string Opt4 { get; set; }
        public string Opt5 { get; set; }


        public FiveWayMCTemplateViewModel(Question question)
        {
            Question = question;
        }

        private void OptionsParser()
        {

        }

    }
}
