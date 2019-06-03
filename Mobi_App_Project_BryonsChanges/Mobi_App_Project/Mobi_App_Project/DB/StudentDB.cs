using System;
using System.Collections.Generic;
using System.Text;

using System.Threading.Tasks;
using SQLite;
using Mobi_App_Project.Models;
using Xamarin.Forms;
using System.Collections.ObjectModel;

namespace Mobi_App_Project.DB
{
    public class StudentDB
    {
        
        static SQLiteAsyncConnection database;
        public StudentDB(SQLiteAsyncConnection db)
        {
            database = db;
            database.CreateTableAsync<Group>();
            //loadData();
        }
        public Task<List<Student>> GetItemsAsync()
        {
            return database.Table<Student>().ToListAsync();
        }

        

        public Task<Student> GetItemAsync(int id)
        {
            return database.Table<Student>().Where(i => i.StudentId == id).FirstOrDefaultAsync();
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
