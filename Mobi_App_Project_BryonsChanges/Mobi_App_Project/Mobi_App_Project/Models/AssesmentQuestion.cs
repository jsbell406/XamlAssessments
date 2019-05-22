using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
namespace Mobi_App_Project.Models
{
   public class AssesmentQuestion
    {
        [PrimaryKey, AutoIncrement]
        public int AssesmentQuestionId { get; set; }
        public int QuestionId { get; set; }
        public int AssessmentId { get; set; }
        public int OrderNum { get; set; }
        //public int ID { get; internal set; }
    }
}
