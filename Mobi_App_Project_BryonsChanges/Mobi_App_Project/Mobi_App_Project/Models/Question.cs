using SQLite;

namespace Mobi_App_Project.Models
{
    public class Question
    {
        [PrimaryKey, AutoIncrement]
        public int QuestionId { get; set; }
        public string Qtype { get; set; }
        public string DisplayText { get; set; }
        public string Option1 { get; set; }
        public string Option2 { get; set; }      
    }
}
