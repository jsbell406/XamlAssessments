﻿using SQLite;

namespace Mobi_App_Project.Models
{
    public class Result
    {
        [PrimaryKey, AutoIncrement]
        public int ResultId { get; set; }      
        public int AssessmentSessionId { get; set; }
        public int AssesmentQuestionId { get; set; }
        public int QuestionId { get; set; }
        public string TextResults { get; set; }
    }
}
