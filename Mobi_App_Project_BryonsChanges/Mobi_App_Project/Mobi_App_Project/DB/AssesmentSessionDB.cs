using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;
using Mobi_App_Project.Models;
using Mobi_App_Project.Helpers;

namespace Mobi_App_Project.DB
{
    public class AssesmentSessionDB
    {
        static SQLiteAsyncConnection database;
        public AssesmentSessionDB(SQLiteAsyncConnection db)
        {
            database = db;

            //AssessmentSessionDbInit();

            database.CreateTableAsync<AssessmentSession>();
            //loadData();
        }

        public async void AssessmentSessionDbInit()
        {
            await database.CreateTableAsync<AssessmentSession>();
        }

        public Task<List<AssessmentSession>> GetItemsAsync()
        {
            return database.Table<AssessmentSession>().ToListAsync();
        }

        public Task<AssessmentSession> GetAssessmentByDate(DateTime date)
        {
            double dateDouble = JulianDateParser.ConverToJD(date);
            return database.Table<AssessmentSession>().Where(a => a.SessionDate == dateDouble).FirstOrDefaultAsync();
        }

        public Task<AssessmentSession> GetAssessmentByDate(string strDate)
        {
            DateTime date = DateTime.Parse(strDate);
            double dateDouble = JulianDateParser.ConverToJD(date);

            return database.Table<AssessmentSession>().Where(a => a.SessionDate == dateDouble).FirstOrDefaultAsync();
        }

        public Task<AssessmentSession> GetAssessmentByDate(double dateDouble)
        {
            return database.Table<AssessmentSession>().Where(a => a.SessionDate == dateDouble).FirstOrDefaultAsync();
        }
        public Task<AssessmentSession> GetItemAsync(int id)
        {
            return database.Table<AssessmentSession>().Where(i => i.StudentId == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(AssessmentSession item)
        {
            if (item.SessionId != 0)
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
