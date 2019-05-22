using System;
using System.Collections.Generic;
using System.Text;

using System.Threading.Tasks;
using SQLite;
using Mobi_App_Project.Models;
using Xamarin.Forms;
namespace Mobi_App_Project.DB
{
    public class ResultDB
    {
        static SQLiteAsyncConnection database;
        public ResultDB(SQLiteAsyncConnection db)
        {
            database = db;
            database.CreateTableAsync<Group>();
            //loadData();
        }
        public Task<List<Result>> GetItemsAsync()
        {
            return database.Table<Result>().ToListAsync();
        }

        //public Task<IList<TodoItem>> GetItemsNotDoneAsync()
        //{
        //    return database.QueryAsync<TodoItem>("SELECT * FROM [TodoItem] WHERE [Done] = 0");
        //}

        public Task<Result> GetItemAsync(int id)
        {
            return database.Table<Result>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(Result item)
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

        public Task<int> DeleteItemAsync(Result item)
        {
            //GetItemAsync(id);
            return database.DeleteAsync(item);
        }
    }
}
