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

        internal object SaveItemAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<Result>> GetItemsAsync()
        {
            return database.Table<Result>().ToListAsync();
        }

        

        public Task<Result> GetItemAsync(int id)
        {
            return database.Table<Result>().Where(i => i.ResultId == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(Result item)
        {
            if (item.ResultId != 0)
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

            return database.DeleteAsync(item);
        }

        public Task<List<Result>> GetResultsByAssessmentSession(int assessmentSessionId)
        {
            return database.Table<Result>().Where(r => r.AssessmentSessionId == assessmentSessionId).ToListAsync();
        }
    }
}
