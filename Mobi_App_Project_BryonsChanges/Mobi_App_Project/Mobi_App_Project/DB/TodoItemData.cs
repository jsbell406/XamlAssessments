using System;
using System.Collections.Generic;
using System.Text;

using System.Threading.Tasks;
using SQLite;
using Mobi_App_Project.Models;
using Xamarin.Forms;

namespace Mobi_App_Project.DB
{
    public class TodoItemData
    {
        static SQLiteAsyncConnection database;

        public TodoItemData()
        {
            //database = DependencyService.Get<AppDatabase>().GetConnection();
            database = App.AppDatabase.GetConnection();
            database.CreateTableAsync<TodoItem>();
            //SaveItemAsync(new TodoItem(0, "Wash Car", "Bring soap", false));
            //SaveItemAsync(new TodoItem(0, "Wash Dog", "Bring shampoo", false));
            //SaveItemAsync(new TodoItem(0, "Buy Oil filter", "", false));
            //SaveItemAsync(new TodoItem(0, "Change Oil", "", false));
        }
        public Task<List<TodoItem>> GetItemsAsync()
        {
            return database.Table<TodoItem>().ToListAsync();
        }

        //public Task<IList<TodoItem>> GetItemsNotDoneAsync()
        //{
        //    return database.QueryAsync<TodoItem>("SELECT * FROM [TodoItem] WHERE [Done] = 0");
        //}

        public Task<TodoItem> GetItemAsync(int id)
        {
            return database.Table<TodoItem>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(TodoItem item)
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

        public Task<int> DeleteItemAsync(TodoItem item)
        {
            //GetItemAsync(id);
            return database.DeleteAsync(item);
        }
    }
}
