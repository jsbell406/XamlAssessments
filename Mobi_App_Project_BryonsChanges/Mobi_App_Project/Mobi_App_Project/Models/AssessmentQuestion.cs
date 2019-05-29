using SQLite;

namespace Mobi_App_Project.Models
{
    public class AssessmentQuestion
    {
        [PrimaryKey, AutoIncrement]
        public int AssessmentQuestionId { get; set; }
        public int QuestionId { get; set; }
        public int AssessmentId { get; set; }
        public int OrderNum { get; set; }      
    }
}
