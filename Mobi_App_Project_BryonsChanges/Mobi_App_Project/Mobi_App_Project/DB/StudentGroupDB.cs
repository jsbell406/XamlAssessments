using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;
using Mobi_App_Project.Models;

namespace Mobi_App_Project.DB
{
    public class StudentGroupDB
    {
        static SQLiteAsyncConnection database;
        public StudentGroupDB(SQLiteAsyncConnection db)
        {
            database = db;

            //StudentGroupDbInit();

            database.CreateTableAsync<StudentGroup>();
            //loadData();
        }

        public async void StudentGroupDbInit()
        {
            await database.CreateTableAsync<StudentGroup>();
        }
        public Task<List<StudentGroup>> GetItemsAsync()
        {
            return database.Table<StudentGroup>().ToListAsync();
        }

        
        public Task<StudentGroup> GetItemAsync(int id)
        {
            return database.Table<StudentGroup>().Where(i => i.StudentGroupId == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(StudentGroup item)
        {
            if (item.StudentGroupId != 0)
            {
                return database.UpdateAsync(item);
            }
            else
            {
                return database.InsertAsync(item);
            }
        }

        public Task<int> DeleteItemAsync(StudentGroup item)
        {
            
            return database.DeleteAsync(item);
        }
    }
}
