using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Mobi_App_Project.Models
{
    public class Result
    {
        [PrimaryKey, AutoIncrement]
        public int ResuldID { get; set; }
        public int AssessmentID { get; set; }
        public string TextResults { get; set; }
        public int AssesmentQuestionId { get; set; }
        public int QuestionID { get; set; }
        public int ID { get; internal set; }

    }
}
