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

        public Task<List<AssessmentQuestion>> GetAssessmentQuestionsByAssessmentId(int assessmentId)
        {
            return database.Table<AssessmentQuestion>().Where(aq => aq.AssessmentId == assessmentId).ToListAsync();
        }

        public Task<AssessmentQuestion> GetFirstAssessmentQuestion(int assessmentId)
        {
            return database.Table<AssessmentQuestion>().Where(aq => aq.AssessmentId == assessmentId && aq.OrderNum == 1).FirstOrDefaultAsync();
        }

        public Task<List<AssessmentQuestion>> GetItemsAsync()
        {
            return database.Table<AssessmentQuestion>().ToListAsync();
        }

        public Task<AssessmentQuestion> GetNextAssessmentQuestion(int assessmentId, int orderNumber)
        {
            orderNumber++;

            return database.Table<AssessmentQuestion>().Where(aq => aq.AssessmentId == assessmentId & aq.OrderNum == orderNumber).FirstOrDefaultAsync();
        }

        //public Task<AssessmentQuestion> GetAssessmentQuestionByQuestionIdAssessmentId(int questionId, int assessmentId)
        //{
        //    return database.Table<AssessmentQuestion>().Where(aq => aq.QuestionId == questionId && aq.AssessmentId == assessmentId).FirstOrDefaultAsync();
        //}

        public  Task<AssessmentQuestion> GetItemAsync(int id)
        {
            return database.Table<AssessmentQuestion>().Where(i => i.AssessmentQuestionId == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(AssessmentQuestion item)
        {
            if (item.AssessmentQuestionId != 0)
            {
                return database.UpdateAsync(item);
            }
            else
            {
                return database.InsertAsync(item);
            }
        }

        public Task<int> DeleteItemAsync(AssessmentQuestion item)
        {          
            return database.DeleteAsync(item);
        }

        internal void DeleteItemAsync(AssessmentQuestion assessmentQuestion)
        {
            throw new NotImplementedException();
        }
    }
}
