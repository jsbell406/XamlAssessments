using System;
using System.Collections.Generic;
using System.Text;

using System.Threading.Tasks;
using SQLite;
using Mobi_App_Project.Models;
using Xamarin.Forms;
namespace Mobi_App_Project.DB
{
    public class AssesmentQuestionDB
    {
        static SQLiteAsyncConnection database;
        public AssesmentQuestionDB(SQLiteAsyncConnection db)
        {
            database = db;
            database.CreateTableAsync<AssesmentQuestion>();
            //loadData();
        }

        public Task<List<AssesmentQuestion>> GetItemsAsync()
        {
            return database.Table<AssesmentQuestion>().ToListAsync();
        }

       

        public  Task<AssesmentQuestion> GetItemAsync(int id)
        {
            return database.Table<AssesmentQuestion>().Where(i => i.AssesmentQuestionId == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(AssesmentQuestion item)
        {
            if (item.AssesmentQuestionId != 0)
            {
                return database.UpdateAsync(item);
            }
            else
            {
                return database.InsertAsync(item);
            }
        }

        public Task<int> DeleteItemAsync(AssesmentQuestionDB item)
        {
            
            return database.DeleteAsync(item);
        }
    }
}
