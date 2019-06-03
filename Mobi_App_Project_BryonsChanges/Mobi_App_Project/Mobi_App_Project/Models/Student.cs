using SQLite;
using System;
using System.Collections.Generic;

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


        

    //public StudentCollection()
    //    {
    //        List<String> studentList = new List<string>();
    //        studentList.Add();
    //        studentList.Add(this.LastName);

    //        return studentList;
            
            

    //    }

    //    public override string ToString()
    //    {
    //        return StudentCollection();

    //    }

    }
}
