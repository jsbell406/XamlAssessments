using SQLite;

namespace Mobi_App_Project.Models
{
    public class Result
    {
        [PrimaryKey, AutoIncrement]
        public int ResuldId { get; set; }      
        public int AssesmentQuestionId { get; set; }
        public int QuestionId { get; set; }
        public string TextResults { get; set; }
        public string AdminNotes { get; set; }
    }
}
