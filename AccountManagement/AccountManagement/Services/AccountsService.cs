using System;
using AccountManagement.Models;
using System.Collections.Generic;
using AccountManagement.Services;
using System.Linq;
using Xamarin.Forms;

[assembly: Xamarin.Forms.Dependency(typeof(AccountsService))]
namespace AccountManagement.Services
{
    public interface IAccountsService
    {
        List<Account> GetAccounts(User user);
    }

    public class AccountsService : IAccountsService
    {
        private readonly IUserService _userService;
        private readonly List<Account> _accounts;

        public AccountsService(IUserService userService = null)
        {
            _accounts = new List<Account>();
            _userService = userService ?? DependencyService.Get<IUserService>();
            InitDummyData();
        }

        public AccountsService() : this(null)
        {
            
        }

        private void InitDummyData()
        {
            var users = _userService.GetUsers();
            foreach (var user in users)
            {
                var currentAccount = new Account(user.UserId, AccountType.Current, 1000);
                _accounts.Add(currentAccount);

                var savingsAccount = new Account(user.UserId, AccountType.Savings, 1000);
                _accounts.Add(savingsAccount);
            }
        }

        public List<Account> GetAccounts(User user)
        {
            return _accounts.Where(account => account.UserId == user.UserId).ToList();
        }
    }
}