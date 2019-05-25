using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Mobi_App_Project.Models
{
   public class Group
    {
        [PrimaryKey, AutoIncrement]
        public int GroupId { get; set; }
        public int StudentId { get; set; }
        public string GroupName { get; set; }
       
    }
}
