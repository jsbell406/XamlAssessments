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

        public override string ToString()
        {
            return string.Format("{0} {1}",FirstName,LastName);
        }

      
        public override bool Equals(object obj)
        {
            Student student = (Student)obj;

            bool isEqual = false;

            if(FirstName == student.FirstName & LastName == student.LastName & MiddleName == student.MiddleName)
            {
                isEqual = true;
            }
            return isEqual;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
