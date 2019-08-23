using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;
using Mobi_App_Project.Models;

namespace Mobi_App_Project.DB
{
    public class AdminUserDB
    {
        static SQLiteAsyncConnection database;

        public string DbName { get; internal set; }

        public AdminUserDB(SQLiteAsyncConnection db)
        {
            database = db;
           // DbName = App.AdminUser.DbName;

            //AdminUserDbInit();
            //int s = database.DropTableAsync<AdminUser>().Result;

            database.CreateTableAsync<AdminUser>();
            DbName = "MyAssessmentsDb";
            //loadData();
        }

        public async void AdminUserDbInit()
        {
            await database.CreateTableAsync<AdminUser>();
        }

        public Task<AdminUser> GetUserByUsername(string userName)
        {
            return database.Table<AdminUser>().Where(a => a.UserName == userName).FirstOrDefaultAsync();
        }



        private void loadData()
        {
            AdminUser user = new AdminUser();
            user.UserName = "a";
            user.Hash = "b";
            user.DbName = user.UserName;
            user.Salt = "a;ldfsdfsdkjf";
            SaveItemAsync(user);
        }
        public Task<List<AdminUser>> GetItemsAsync()
        {         
            return database.Table<AdminUser>().ToListAsync();          
        }

       

        public Task<AdminUser> GetItemAsync(int id)
        {
            return database.Table<AdminUser>().Where(i => i.AdminUserId == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(AdminUser item)
        {
            if (item.AdminUserId != 0)
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
            
            return database.DeleteAsync(item);
        }
    }
}
