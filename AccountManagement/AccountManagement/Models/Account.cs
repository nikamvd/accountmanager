using System;
namespace AccountManagement.Models
{
	public enum AccountType
	{
		Current,
		Savings,
		Loan
	}

	public class Account : ViewModels.Base.ExtendedBindableObject
    {
		public Account(string userId, AccountType accountType, double balance)
		{
            AccountId = Guid.NewGuid().ToString("N");
            UserId = userId;
			AccountType = accountType;
			Balance = balance;
        }

        public string AccountId { get; }
        public string UserId { get; }
		public AccountType AccountType { get; }

        private double _balance;
        public double Balance
        {
            get => _balance;
            set
            {
                _balance = value;
                RaisePropertyChanged(() => Balance);
            }
        }
    }
}

