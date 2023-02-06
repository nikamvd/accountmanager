using System;
using System.Threading.Tasks;
using AccountManagement.Services.Dialog;
using AccountManagement.Services.Navigation;
using Xamarin.Forms;

[assembly: Xamarin.Forms.Dependency(typeof(NavigationService))]
namespace AccountManagement.Services.Navigation
{
	public class NavigationService : INavigationService
    {
        public async Task PushAsync(Page page)
        {
            await App.Current.MainPage.Navigation.PushAsync(page);
        }

        public Task<bool> PushAsRoot(Page page)
        {
            var navigationPage = new NavigationPage(page);
            App.Current.MainPage = navigationPage;
            return Task.FromResult(true);
        }
    }
}

