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
            OptionsParser();
        }

        private void OptionsParser()
        {
            char[] delim = ",".ToCharArray();
            string[] options = Question.Option1.Split(delim);
            Opt1 = options[0];
            Opt2 = options[1];
            Opt3 = options[2];
            Opt4 = options[3];
            Opt5 = options[4];
        }
    }
}
