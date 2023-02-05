using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AccountManagement.Views;
using AccountManagement.ViewModels;

namespace AccountManagement
{
    public partial class App : Application
    {
        public App ()
        {
            InitializeComponent();

            var loginView = new LoginView()
            {
                BindingContext = new LoginViewModel()
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

