using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;
using Mobi_App_Project.Models;

namespace Mobi_App_Project.DB
{
    public class QuestionDB
    {
        static SQLiteAsyncConnection database;
        public QuestionDB(SQLiteAsyncConnection db)
        {
            database = db;

            //QuestionDbInit();

            database.CreateTableAsync<Question>();
            //loadData();

        }

        public async void QuestionDbInit()
        {
            await database.CreateTableAsync<Question>();
        }
       
        public Task<Question> GetQuestionByDisplayText(string displayText)
        {
            return database.Table<Question>().Where(q => q.DisplayText == displayText).FirstOrDefaultAsync();
        }

        public Task<List<Question>> GetItemsAsync()
        {
            return database.Table<Question>().ToListAsync();
        }

     
        public Task<Question> GetItemAsync(int id)
        {
            return database.Table<Question>().Where(i => i.QuestionId == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(Question item)
        {
            if (item.QuestionId != 0)
            {
                return database.UpdateAsync(item);
            }
            else
            {
                return database.InsertAsync(item);
            }
        }

        public Task<int> DeleteItemAsync(Question item)
        {
            
            return database.DeleteAsync(item);
        }
    }
}
