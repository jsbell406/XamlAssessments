using System;
using System.Collections.Generic;
using System.Text;

using System.Threading.Tasks;
using SQLite;
using Mobi_App_Project.Models;
using Xamarin.Forms;

namespace Mobi_App_Project.DB
{
    public class AssesmentSessionDB
    {
        static SQLiteAsyncConnection database;
        public AssesmentSessionDB(SQLiteAsyncConnection db)
        {
            database = db;
            database.CreateTableAsync<AssessmentSession>();
            //loadData();
        }

        public Task<List<AssessmentSession>> GetItemsAsync()
        {
            return database.Table<AssessmentSession>().ToListAsync();
        }

        
        public Task<AssessmentSession> GetItemAsync(int id)
        {
            return database.Table<AssessmentSession>().Where(i => i.StudentId == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(AssessmentSession item)
        {
            if (item.StudentId != 0)
            {
                return database.UpdateAsync(item);
            }
            else
            {
                return database.InsertAsync(item);
            }
        }

        public Task<int> DeleteItemAsync(AssessmentSession item)
        {
            
            return database.DeleteAsync(item);
        }
    }
}
