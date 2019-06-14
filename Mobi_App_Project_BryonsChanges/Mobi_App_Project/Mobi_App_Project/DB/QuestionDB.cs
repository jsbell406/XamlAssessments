using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Common;
using System.Threading.Tasks;
using SQLite;
using Mobi_App_Project.Models;
using Xamarin.Forms;
using SQLiteNetExtensionsAsync.Extensions;

namespace Mobi_App_Project.DB
{
    public class QuestionDB
    {
        static SQLiteAsyncConnection database;
        public QuestionDB(SQLiteAsyncConnection db)
        {
            database = db;
            database.CreateTableAsync<Question>();
            //loadData();
        }

        public Task<List<Question>> GetItemsAsync()
        {
            return database.Table<Question>().ToListAsync();
        }

        public Task<Question> GetNextQuestion(int assessmentId, int orderNum)
        {

            AssessmentQuestion ques = database.Table<AssessmentQuestion>().Where(aq => aq.AssessmentId == assessmentId && aq.OrderNum == orderNum).FirstOrDefaultAsync().Result;
            return database.Table<Question>().Where(q => q.QuestionId == ques.QuestionId).FirstOrDefaultAsync();           
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
