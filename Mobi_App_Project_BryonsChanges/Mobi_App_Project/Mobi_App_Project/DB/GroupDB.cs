﻿using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;
using Mobi_App_Project.Models;

namespace Mobi_App_Project.DB
{
    public class GroupDB
    {
        static SQLiteAsyncConnection database;

        public GroupDB(SQLiteAsyncConnection db)
        {
            database = db;

            //GroupDbInit();

            database.CreateTableAsync<Group>();
            //loadData();
        }

        public async void GroupDbInit()
        {
            await database.CreateTableAsync<Group>();
        }

        public Task<List<Group>> GetItemsAsync()
        {
            return database.Table<Group>().ToListAsync();
        }
        
        public Task<Group> GetItemAsync(int id)
        {
            return database.Table<Group>().Where(i => i.GroupId == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(Group item)
        {
            if (item.GroupId != 0)
            {
                return database.UpdateAsync(item);
            }
            else
            {
                return database.InsertAsync(item);
            }
        }

        public Task<int> DeleteItemAsync(Group item)
        {
            //GetItemAsync(id);
            return database.DeleteAsync(item);
        }
    }
}
