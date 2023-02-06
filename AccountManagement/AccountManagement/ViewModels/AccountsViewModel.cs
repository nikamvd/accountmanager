using System;
using AccountManagement.ViewModels.Base;
using AccountManagement.Services.Dialog;
using AccountManagement.Services.Navigation;
using AccountManagement.Models;
using System.Collections.ObjectModel;
using AccountManagement.Services;
using Xamarin.Forms;
using System.Collections.Generic;
using AccountManagement.Validations;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Linq;
using AccountManagement.Services.Loan;

namespace AccountManagement.ViewModels
{
	public class AccountsViewModel : ViewModelBase
    {
        private readonly IAccountsService _accountsService;

        private User _user;
        private ValidatableObject<Loan> _loan;
        private ObservableCollection<Account> _accounts;

        public AccountsViewModel(User user,
            IAccountsService accountsService = null,
            IDialogService dialogService = null,
            INavigationService navigationService = null)
            : base(dialogService, navigationService)
        {
            _accountsService = accountsService ?? DependencyService.Get<IAccountsService>();
            User = user;
            Accounts = new ObservableCollection<Account>(_accountsService.GetAccounts(User));

            Loan = new ValidatableObject<Loan>() { Value = new Loan() { Duration = 1 } };
            AddLoanValidations();

            MoneyTransferViewModel = new ValidatableObject<MoneyTransferViewModel>() { Value = new MoneyTransferViewModel() };
            AddTransferValidations();
        }

        public User User
        {
            get => _user;
            set
            {
                _user = value;
                RaisePropertyChanged(() => User);
            }
        }

        public ObservableCollection<Account> Accounts
        {
            get => _accounts;
            set
            {
                _accounts = value;
                RaisePropertyChanged(() => Accounts);
            }
        }

        public ValidatableObject<Loan> Loan
        {
            get => _loan;
            set
            {
                _loan = value;
                RaisePropertyChanged(() => Loan);
            }
        }

        public List<int> DurationList
        {
            get
            {
                return new List<int>()
                {
                    1, 3, 5
                };
            }
        }

        #region LoanApplication

        private void AddLoanValidations()
        {
            _loan.Validations.Add(new IsValidAmountRule { ValidationMessage = "Please enter loan amount upto 10,000." });
            _loan.Validations.Add(new IsLoanAllowedRule(User.CreditRating) { ValidationMessage = $"{User.UserName}'s creadit rating is less than 20. Loan request not allowed." });
        }

        public ICommand CalculateInterestCommand => new Command(async () => await CalculateInterestAsync());
        private async Task CalculateInterestAsync()
        {
            if (Loan.Validate())
            {
                CalculateInterest();
            }
            else
            {
                await DialogService.ShowAlertAsync(Loan.Errors.FirstOrDefault(), "Loan Error", "OK");
            }
        }

        private void CalculateInterest()
        {
            if (User.CreditRating > 50)
            {
                InterestCalculator calculator = new InterestCalculator(new HighRatingCalculator());
                Loan.Value.Interest = calculator.Calculate(Loan.Value);
            }
            else
            {
                InterestCalculator calculator = new InterestCalculator(new LowRatingCalculator());
                Loan.Value.Interest = calculator.Calculate(Loan.Value);
            }
            RaisePropertyChanged(() => Loan);
        }

        public ICommand ApplyCommand => new Command(async () => await ApplyAsync());
        private async Task ApplyAsync()
        {
            if (Loan.Validate())
            {
                CalculateInterest();

                var loanAccount = new Account(User.UserId, AccountType.Loan, Loan.Value.Amount);
                Accounts.Add(loanAccount);
            }
            else
            {
                await DialogService.ShowAlertAsync(Loan.Errors.FirstOrDefault(), "Loan Error", "OK");
            }
        }

        #endregion LoanApplication

        #region MoneyTransfer

        private void AddTransferValidations()
        {
            _moneyTransferViewModel.Validations.Add(new AreAccountsSelectedRule { ValidationMessage = "Please select From and To Accounts both." });
            _moneyTransferViewModel.Validations.Add(new AreToAndFromDifferentRule { ValidationMessage = "To and From Accounts should be different." });
            _moneyTransferViewModel.Validations.Add(new TransferAmountSpecifiedRule { ValidationMessage = "Please enter amount to transfer." });
            _moneyTransferViewModel.Validations.Add(new IsEnoughBalanceRule { ValidationMessage = "From Account doesn't have sufficient balance." });
        }

        private ValidatableObject<MoneyTransferViewModel> _moneyTransferViewModel;
        public ValidatableObject<MoneyTransferViewModel> MoneyTransferViewModel
        {
            get => _moneyTransferViewModel;
            set
            {
                _moneyTransferViewModel = value;
                RaisePropertyChanged(() => MoneyTransferViewModel);
            }
        }

        public ICommand TransferCommand => new Command(async () => await TransferAsync());
        private async Task TransferAsync()
        {
            if (MoneyTransferViewModel.Validate())
            {
                var fromAccount = Accounts.Where(account => account.AccountId == MoneyTransferViewModel.Value.FromAccount.AccountId).FirstOrDefault();
                var toAccount = Accounts.Where(account => account.AccountId == MoneyTransferViewModel.Value.ToAccount.AccountId).FirstOrDefault();

                if(fromAccount != null && toAccount != null)
                {
                    fromAccount.Balance -= MoneyTransferViewModel.Value.AmountToTransfer;
                    toAccount.Balance += MoneyTransferViewModel.Value.AmountToTransfer;
                    RaisePropertyChanged(() => MoneyTransferViewModel.Value.FromAccount.Balance);
                    RaisePropertyChanged(() => MoneyTransferViewModel.Value.ToAccount.Balance);
                }
            }
            else
            {
                await DialogService.ShowAlertAsync(MoneyTransferViewModel.Errors.FirstOrDefault(), "Transfer Error", "OK");
            }
        }

        #endregion MoneyTransfer

        #region Logout

        public ICommand LogoutCommand => new Command(async () => await LogoutAsync());
        private async Task LogoutAsync()
        {
            var loginView = new Views.LoginView()
            {
                BindingContext = new LoginViewModel()
            };
            await NavigationService.PushAsRoot(loginView);
        }

        #endregion Logout

    }
}

