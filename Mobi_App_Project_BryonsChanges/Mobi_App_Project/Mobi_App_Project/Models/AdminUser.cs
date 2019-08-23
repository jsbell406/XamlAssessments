using SQLite;

namespace Mobi_App_Project.Models
{
    public class AdminUser
    {
        [PrimaryKey, AutoIncrement]
        public int AdminUserId { get; set; }
        public string UserName { get; set; }
        public string Pin { get; set; }
        public string Salt { get; set; }
        public string Hash { get; set; }
        public string DbName { get; set; }

    }
}
