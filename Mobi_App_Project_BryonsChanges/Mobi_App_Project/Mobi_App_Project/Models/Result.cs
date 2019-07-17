using SQLite;

namespace Mobi_App_Project.Models
{
    public class Result
    {
        [PrimaryKey, AutoIncrement]
<<<<<<< HEAD
        public int ResultId { get; set; }      
=======
        public int ResuldId { get; set; }      
        public int AssessmentSessionId { get; set; }
>>>>>>> dev
        public int AssesmentQuestionId { get; set; }
        public int QuestionId { get; set; }
        public string TextResults { get; set; }
        public int AssessmentSessionId { get; set; }
    }
}
