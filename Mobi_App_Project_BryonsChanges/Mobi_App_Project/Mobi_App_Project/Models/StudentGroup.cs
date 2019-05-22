using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Mobi_App_Project.Models
{
    public class StudentGroup
    {
        [PrimaryKey, AutoIncrement]
        public int StudentGroupId { get; set; }
        public int GroupId { get; set; }
        public int StudentId { get; set; }
        //public int ID { get; internal set; }

    }
}
