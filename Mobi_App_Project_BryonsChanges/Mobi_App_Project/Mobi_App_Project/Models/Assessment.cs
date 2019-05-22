using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Mobi_App_Project.Models
{
    public class Assessment
    {
        public static int ID { get; internal set; }
        [PrimaryKey, AutoIncrement]
        public int AssessmentID { get; set; }
        public string AssesName { get; set; }
        
    }
}
