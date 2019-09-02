using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;
using Mobi_App_Project.Models;
using System.Collections.ObjectModel;

namespace Mobi_App_Project.DB
{
    public class StudentDB
    {
        
        static SQLiteAsyncConnection database;
        public StudentDB(SQLiteAsyncConnection db)
        {
            database = db;

            //StudentDbInit();
            
            database.CreateTableAsync<Student>();
            //loadData();
        }

        public async void StudentDbInit()
        {
            await database.CreateTableAsync<Student>();
        }

        public Task<List<Student>> GetItemsAsync()
        {
            return database.Table<Student>().ToListAsync();
        }

        public SQLiteAsyncConnection GetConnection()
        {
            return database;
        }



        public Task<Student> GetItemAsync(int id)
        {
            return database.Table<Student>().Where(i => i.StudentId == id).FirstOrDefaultAsync();
        }

        public Task<Student> GetStudentByName(string firstName, string middleName, string lastName)
        {
            return database.Table<Student>().Where(s => s.FirstName.ToUpper() == firstName.ToUpper() & s.MiddleName.ToUpper() == middleName.ToUpper() & s.LastName.ToUpper() == lastName.ToUpper()).FirstOrDefaultAsync();
        }

        public Task<Student> GetStudentByName(string firstName, string lastName)
        {
            return database.Table<Student>().Where(s => s.FirstName.ToUpper() == firstName.ToUpper() & s.LastName.ToUpper() == lastName.ToUpper()).FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(Student item)
        {
            if (item.StudentId != 0)
            {
                return database.UpdateAsync(item);
            }
            else
            {
                return database.InsertAsync(item);
            }
        }

        public Task<int> DeleteItemAsync(Student item)
        {
            //GetItemAsync(id);
            return database.DeleteAsync(item);
        }

        internal void SaveItemAsync(ObservableCollection<string> myStudents)
        {
            throw new NotImplementedException();
        }
    }
}
