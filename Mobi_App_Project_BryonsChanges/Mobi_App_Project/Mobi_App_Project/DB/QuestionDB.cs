using System;
using System.Collections.Generic;
using System.Text;

using System.Threading.Tasks;
using SQLite;
using Mobi_App_Project.Models;
using Xamarin.Forms;

namespace Mobi_App_Project.DB
{
    public class QuestionDB
    {
        static SQLiteAsyncConnection database;
        public QuestionDB(SQLiteAsyncConnection db)
        {
            database = db;
            database.CreateTableAsync<Group>();
            //loadData();
        }
        public Task<List<Question>> GetItemsAsync()
        {
            return database.Table<Question>().ToListAsync();
        }

        //public Task<IList<TodoItem>> GetItemsNotDoneAsync()
        //{
        //    return database.QueryAsync<TodoItem>("SELECT * FROM [TodoItem] WHERE [Done] = 0");
        //}

        public Task<Question> GetItemAsync(int id)
        {
            return database.Table<Question>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(Question item)
        {
            if (item.ID != 0)
            {
                return database.UpdateAsync(item);
            }
            else
            {
                return database.InsertAsync(item);
            }
        }

        public Task<int> DeleteItemAsync(Question item)
        {
            //GetItemAsync(id);
            return database.DeleteAsync(item);
        }
    }
}
