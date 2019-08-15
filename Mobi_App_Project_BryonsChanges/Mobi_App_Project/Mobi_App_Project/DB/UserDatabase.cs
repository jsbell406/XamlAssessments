using SQLite;
using Mobi_App_Project.Models;

namespace Mobi_App_Project.Services
{
    public class UserDatabase
    {
        readonly SQLiteAsyncConnection database;
        public UserDatabase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<TodoItem>().Wait();
        }

        public UserDatabase()
        {
            string dbPath = "";
            database = new SQLiteAsyncConnection(dbPath);
            //database.CreateTableAsync<TodoItem>().Wait();
        }

        public SQLiteAsyncConnection GetConnection()
        {
            return database;

        }
    }
}
