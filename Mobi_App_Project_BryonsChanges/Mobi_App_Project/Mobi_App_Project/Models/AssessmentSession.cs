using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Mobi_App_Project.Models
{
    public class AssessmentSession
    {
        [PrimaryKey, AutoIncrement]
        public int SessionId { get; set; }
        public int StudentId { get; set; }
        public double SessionDate { get; set; }
        public int AssessmentId { get; set; }
        public int GroupId { get; set; }
        
    }
}
