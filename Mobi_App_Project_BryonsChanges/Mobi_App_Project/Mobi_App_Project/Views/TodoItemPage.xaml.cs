using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Mobi_App_Project.Models;

namespace Mobi_App_Project.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TodoItemPage : ContentPage
    {
        public TodoItemPage()
        {
            InitializeComponent();
        }

        async void OnSaveClicked(object sender, EventArgs e)
        {
            var todoItem = (TodoItem)BindingContext;
            //await TodoDataStore.SaveItemAsync(todoItem);
            //await Navigation.PopAsync();

            MessagingCenter.Send(this, "AddItem", todoItem);
            //await Navigation.PopModalAsync();

            await Navigation.PushAsync(new TodoListPage());


        }

        async void OnDeleteClicked(object sender, EventArgs e)
        {
            var todoItem = (TodoItem)BindingContext;
            //await App.Database.DeleteItemAsync(todoItem);
            MessagingCenter.Send(this, "DeleteItem", todoItem);
            await Navigation.PopAsync();
        }

        async void OnCancelClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        //void OnSpeakClicked(object sender, EventArgs e)
        //{
        //    var todoItem = (TodoItem)BindingContext;
        //    DependencyService.Get<ITextToSpeech>().Speak(todoItem.Name + " " + todoItem.Notes);
        //}
    }
}