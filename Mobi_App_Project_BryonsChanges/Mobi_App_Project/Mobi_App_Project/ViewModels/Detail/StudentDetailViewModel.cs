using Mobi_App_Project.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Mobi_App_Project.ViewModels.Detail
{
    public class StudentDetailViewModel : BaseViewModel
    {
        public Student Student { get; set; }
        public Dictionary<string, Assessment> Assessments { get; set; }
        public ObservableCollection<string> AssessmentsList { get; set; }

        public StudentDetailViewModel(Student student)
        {
            AssessmentsList = new ObservableCollection<string>();
            Assessments = new Dictionary<string, Assessment>();
            Student = student;
        }
    }
}
