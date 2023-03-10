using System;
using System.Threading.Tasks;
using System.Windows.Input;
using AccountManagement.Services.Dialog;
using AccountManagement.Services.Navigation;
using AccountManagement.Validations;
using AccountManagement.ViewModels.Base;
using Xamarin.Forms;
using System.Linq;
using AccountManagement.Views;
using AccountManagement.Services;
using AccountManagement.Models;

namespace AccountManagement.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        private ValidatableObject<string> _userName;
        private readonly IUserService _userService;
        private readonly IAccountsService _accountsService;

        public LoginViewModel(IUserService userService = null,
            IAccountsService accountsService = null,
            IDialogService dialogService = null,
            INavigationService navigationService = null)
            : base(dialogService, navigationService)
        {
            _userService = userService ?? DependencyService.Get<IUserService>();
            _accountsService = accountsService ?? DependencyService.Get<IAccountsService>();
            _userName = new ValidatableObject<string>();
            AddValidations();
        }

        public ValidatableObject<string> UserName
        {
            get => _userName;
            set
            {
                _userName = value;
                RaisePropertyChanged(() => UserName);
            }
        }

        public ICommand LogInCommand => new Command(async () => await LogInAsync());
        private async Task LogInAsync()
        {
            if(UserName.Validate())
            {
                var user = _userService.GetUser(UserName.Value);
                var accountsViewModel = new AccountsViewModel(user, _accountsService,
                    DialogService, NavigationService);
                var accountsView = new AccountsView()
                {
                    BindingContext = accountsViewModel
                };
                await NavigationService.PushAsRoot(accountsView);
            }
            else
            {
                await DialogService.ShowAlertAsync(UserName.Errors.FirstOrDefault(), "Login Error", "OK");
            }
        }

        private void AddValidations()
        {
            _userName.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "A username is required." });
            _userName.Validations.Add(new IsValidUserRule(_userService) { ValidationMessage = "Invalid username entered." });
        }
    }
}

