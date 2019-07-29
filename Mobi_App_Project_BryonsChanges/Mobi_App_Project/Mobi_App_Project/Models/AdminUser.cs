using SQLite;

namespace Mobi_App_Project.Models
{
    public class AdminUser : ObservableObject
    {
        private int id;
        private string userName;
        private string instructorName;
        private string dbName;
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }

        [PrimaryKey, AutoIncrement]
        public int ID { get => id; set => SetProperty(ref id, value); }
        public string UserName { get => userName; set => SetProperty(ref userName, value); }
        public string InstructorName { get => instructorName; set => SetProperty(ref instructorName, value); }
        public string DBName { get => dbName; set => SetProperty(ref dbName, value); }
    }
}
