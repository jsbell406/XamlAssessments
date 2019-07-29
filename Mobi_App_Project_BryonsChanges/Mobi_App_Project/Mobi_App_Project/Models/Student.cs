using SQLite;

namespace Mobi_App_Project.Models
{
    public class Student
    {
        [PrimaryKey, AutoIncrement]
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public int Age { get; set; }
        public string Grade { get; set; }
    }
}
