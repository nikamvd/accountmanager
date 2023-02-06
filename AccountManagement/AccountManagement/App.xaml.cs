using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AccountManagement.Views;
using AccountManagement.ViewModels;
using AccountManagement.Services;
using AccountManagement.Services.Dialog;
using AccountManagement.Services.Navigation;

namespace AccountManagement
{
    public partial class App : Application
    {
        public App () : this(null, null, null, null) { }

        public App(IUserService userService = null,
            IAccountsService accountsService = null,
            IDialogService dialogService = null,
            INavigationService navigationService = null)
        {
            InitializeComponent();

            var loginView = new LoginView()
            {
                BindingContext = new LoginViewModel(userService, accountsService, dialogService, navigationService)
            };
            var navigationPage = new NavigationPage(loginView);
            MainPage = navigationPage;
        }

        protected override void OnStart ()
        {
        }

        protected override void OnSleep ()
        {
        }

        protected override void OnResume ()
        {
        }
    }
}

