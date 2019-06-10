using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using Mobi_App_Project.Models;
using Xamarin.Forms;

namespace Mobi_App_Project.DB
{
    public class AssesmentDB
    {
        static SQLiteAsyncConnection database;

        public AssesmentDB(SQLiteAsyncConnection db)
        {
            database = db;
            database.CreateTableAsync<Assessment>();
            //loadData();
        }

        public Task<List<Assessment>> GetItemsAsync()
        {
            return database.Table<Assessment>().ToListAsync();
        }

        //public Task<IList<TodoItem>> GetItemsNotDoneAsync()
        //{
        //    return database.QueryAsync<TodoItem>("SELECT * FROM [TodoItem] WHERE [Done] = 0");
        //}

        public Task<Assessment> GetItemAsync(int id)
        {
            return database.Table<Assessment>().Where(i => i.AssessmentId == id).FirstOrDefaultAsync();
        }

        public Task<Assessment> GetAssessmentByAssessNameAsync(string assessName)
        {
            return database.Table<Assessment>().Where(a => a.AssessName == assessName).FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(Assessment item)
        {
            
            if (item.AssessmentId != 0)
            {
                return database.UpdateAsync(item);
            }
            else
            {
                return database.InsertAsync(item);
            }
        }

        public Task<int> DeleteItemAsync(Assessment item)
        {
            //GetItemAsync(id);
            return database.DeleteAsync(item);
        }
    }
}
