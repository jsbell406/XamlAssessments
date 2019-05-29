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
            database.CreateTableAsync<AssessmentQuestion>();
            //loadData();
        }

        public Task<List<AssessmentQuestion>> GetItemsAsync()
        {
            return database.Table<AssessmentQuestion>().ToListAsync();
        }

       

        public  Task<AssessmentQuestion> GetItemAsync(int id)
        {
            return database.Table<AssessmentQuestion>().Where(i => i.AssesmentQuestionId == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(AssessmentQuestion item)
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
