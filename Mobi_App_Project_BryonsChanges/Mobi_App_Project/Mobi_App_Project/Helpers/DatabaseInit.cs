using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Mobi_App_Project.Models;

namespace Mobi_App_Project.Helpers
{
    public class DatabaseInit
    {
        public DatabaseInit()
        {
            Seed();
        }

        private void Seed()
        {
           // List<Student> students = App.StudentDB.GetItemsAsync().Result;
           // if (students.Count == 0)
           // {
                Student s1 = new Student();
                s1.FirstName = "James";
                s1.MiddleName = "Spencer";
                s1.LastName = "Bell";
                s1.Grade = "K";
                s1.Age = 5;

                Student s2 = new Student();
                s2.FirstName = "Garret";
                s2.MiddleName = "Danger";
                s2.LastName = "Allen";
                s2.Grade = "1";
                s2.Age = 6;

                Student s3 = new Student();
                s3.FirstName = "Bryon";
                s3.MiddleName = "Byron";
                s3.LastName = "Steinwand";
                s3.Grade = "2";
                s3.Age = 7;

                App.StudentDB.SaveItemAsync(s1);
                App.StudentDB.SaveItemAsync(s2);
                App.StudentDB.SaveItemAsync(s3);
           // }
        }      
    }
}
