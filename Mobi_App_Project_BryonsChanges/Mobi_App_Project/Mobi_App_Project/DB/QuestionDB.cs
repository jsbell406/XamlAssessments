using System;
using System.Collections.Generic;
using System.Text;

using System.Threading.Tasks;
using SQLite;
using Mobi_App_Project.Models;
using Xamarin.Forms;

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
            AssessmentQuestion assessmentQuestion = App.AssesmentQuestionDB.GetNextAssessmentQuestion(assessmentId, orderNum).Result;

            return database.Table<Question>().Where(q => q.QuestionId == assessmentQuestion.QuestionId).FirstOrDefaultAsync();
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
