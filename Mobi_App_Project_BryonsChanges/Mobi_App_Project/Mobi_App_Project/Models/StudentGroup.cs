﻿using SQLite;

namespace Mobi_App_Project.Models
{
    public class StudentGroup
    {
        [PrimaryKey, AutoIncrement]
        public int StudentGroupId { get; set; }
        public int GroupId { get; set; }
        public int StudentId { get; set; }       
    }
}
