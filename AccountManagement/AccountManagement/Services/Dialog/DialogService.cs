using System;
using System.Threading.Tasks;
using AccountManagement.Services.Dialog;

[assembly: Xamarin.Forms.Dependency(typeof(DialogService))]
namespace AccountManagement.Services.Dialog
{
    public class DialogService : IDialogService
    {
        public Task ShowAlertAsync(string message, string title, string buttonLabel)
        {
            return App.Current.MainPage.DisplayAlert(title, message, buttonLabel);
        }
    }
}

