using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Mobi_App_Project.Models;
using Mobi_App_Project.DB;

namespace Mobi_App_Project.Services
{
    public interface IDataStore<T>
    {
        Task<int> AddItemAsync(T item);
        Task<int> UpdateItemAsync(T item);
        Task<int> DeleteItemAsync(T item);
        Task<T> GetItemAsync(int id);
        Task<List<T>> GetItemsAsync(bool forceRefresh = false);
    }
}
