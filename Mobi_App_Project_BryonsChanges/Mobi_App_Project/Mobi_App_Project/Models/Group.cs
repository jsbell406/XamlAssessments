using SQLite;

namespace Mobi_App_Project.Models
{
    public class Group
    {
        [PrimaryKey, AutoIncrement]
        public int GroupId { get; set; }
        public int StudentGroupId { get; set; }
        public string GroupName { get; set; }      
    }
}
