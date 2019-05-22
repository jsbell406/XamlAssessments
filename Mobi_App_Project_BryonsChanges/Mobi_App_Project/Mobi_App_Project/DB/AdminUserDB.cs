using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using Mobi_App_Project.Models;

namespace Mobi_App_Project.DB
{
    public class AdminUserDB
    {
        static SQLiteAsyncConnection database;

        public string DBName { get; internal set; }

        public AdminUserDB(SQLiteAsyncConnection db)
        {
            database = db;
            database.CreateTableAsync<AdminUser>();
            //loadData();
        }

        private void loadData()
        {
            AdminUser user = new AdminUser();
            user.UserName = "a";
            user.PasswordHash = "b";
            user.DBName = user.UserName;
            user.InstructorName = "Bob";
            user.PasswordSalt = "a;ldfsdfsdkjf";
            SaveItemAsync(user);
        }
        public Task<List<AdminUser>> GetItemsAsync()
        {
            //database.CreateTableAsync<AdminUser>();

            //AdminUser user = new AdminUser();
            //user.UserName = "GarretA";
            //user.PasswordHash = "Password01";
            //user.DBName = user.UserName;
            //user.InstructorName = "Alice";
            //user.PasswordSalt = "a;lsdkjf";
            //SaveItemAsync(user);
            //var users = GetItemsAsync();
            //App.AdminUsers = users;
            return database.Table<AdminUser>().ToListAsync();
           
        }

        //public Task<IList<TodoItem>> GetItemsNotDoneAsync()
        //{
        //    return database.QueryAsync<TodoItem>("SELECT * FROM [TodoItem] WHERE [Done] = 0");
        //}

        public Task<AdminUser> GetItemAsync(int id)
        {
            return database.Table<AdminUser>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(AdminUser item)
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

        public Task<int> DeleteItemAsync(AdminUser item)
        {
            //GetItemAsync(id);
            return database.DeleteAsync(item);
        }
    }
}
