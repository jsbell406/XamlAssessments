using System;
using System.Collections.Generic;
using System.Text;

using System.Threading.Tasks;
using SQLite;
using Mobi_App_Project.Models;
using Xamarin.Forms;

namespace Mobi_App_Project.DB
{
    public class StudentGroupDB
    {
        static SQLiteAsyncConnection database;
        public StudentGroupDB(SQLiteAsyncConnection db)
        {
            database = db;
            database.CreateTableAsync<Group>();
            //loadData();
        }
        public Task<List<StudentGroup>> GetItemsAsync()
        {
            return database.Table<StudentGroup>().ToListAsync();
        }

        //public Task<IList<TodoItem>> GetItemsNotDoneAsync()
        //{
        //    return database.QueryAsync<TodoItem>("SELECT * FROM [TodoItem] WHERE [Done] = 0");
        //}

        public Task<StudentGroup> GetItemAsync(int id)
        {
            return database.Table<StudentGroup>().Where(i => i.StudentGroupId == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(StudentGroup item)
        {
            if (item.StudentGroupId != 0)
            {
                return database.UpdateAsync(item);
            }
            else
            {
                return database.InsertAsync(item);
            }
        }

        public Task<int> DeleteItemAsync(StudentGroup item)
        {
            //GetItemAsync(id);
            return database.DeleteAsync(item);
        }
    }
}
