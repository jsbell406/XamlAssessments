using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;
using Mobi_App_Project.Services;
using Mobi_App_Project.Models;
using Mobi_App_Project.Views;

namespace Mobi_App_Project.ViewModels
{
    class TodoItemsViewModel : BaseViewModel
    {
        public ObservableCollection<TodoItem> Items { get; set; }
        public Command LoadItemsCommand { get; set; }

        public TodoItemsViewModel()
        {
            Title = "Browse";
            Items = new ObservableCollection<TodoItem>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
            MessagingCenter.Subscribe<TodoItemPage, TodoItem>(this, "AddItem", async (obj, item) =>
            {
                var newItem = item as TodoItem;
                Items.Add(newItem);
                await TodoDataStore.AddItemAsync(newItem);
            });

            MessagingCenter.Subscribe<TodoItemPage, TodoItem>(this, "DeleteItem", async (obj, item) =>
            {
                var todoItem = item as TodoItem;
                await TodoDataStore.DeleteItemAsync(todoItem);
            });


        }

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Items.Clear();
                var items = await TodoDataStore.GetItemsAsync(true);
                foreach (var item in items)
                {
                    Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

    }
}
