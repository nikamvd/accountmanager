using System;
namespace AccountManagement.Models
{
	public enum AccountType
	{
		Current,
		Savings,
		Loan
	}

	public class Account
	{
		public Account(string userId, AccountType accountType, double balance)
		{
			UserId = userId;
			AccountType = accountType;
			Balance = balance;
        }

        public string UserId { get; }
		public AccountType AccountType { get; }
        public double Balance { get; set; }
    }
}

