﻿using System;
using System.Collections.Generic;
using System.Text;

using System.Threading.Tasks;
using SQLite;
using Mobi_App_Project.Models;
using Mobi_App_Project.Services;

namespace Mobi_App_Project.DB
{
    public class AppDatabase : ISQLite
    {
        readonly SQLiteAsyncConnection database;
        public AppDatabase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            //database.CreateTableAsync<AdminUser>().Wait();
        
        }

        public AppDatabase()
        {
            string dbPath = "";
            database = new SQLiteAsyncConnection(dbPath);
            //database.CreateTableAsync<TodoItem>().Wait();
        }

        public SQLiteAsyncConnection GetConnection()
        {
            return database;
        }



    }
}
