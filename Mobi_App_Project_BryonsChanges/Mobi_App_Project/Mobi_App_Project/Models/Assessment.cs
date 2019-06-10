using SQLite;

namespace Mobi_App_Project.Models
{
    public class Assessment
    {
        [PrimaryKey, AutoIncrement]
        public int AssessmentId { get; set; }
        public string AssessName { get; set; }    
    }
}
