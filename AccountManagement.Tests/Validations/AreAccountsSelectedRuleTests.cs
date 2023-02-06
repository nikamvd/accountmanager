using System;
using Xunit;
using AccountManagement.Validations;
using AccountManagement.ViewModels;
using AccountManagement.Models;

namespace AccountManagement.Tests.Validations
{
	public class AreAccountsSelectedRuleTests : BaseTests
    {
        private readonly AreAccountsSelectedRule _validationRule;
        private readonly ValidatableObject<MoneyTransferViewModel> _moneyTransferViewModel;
        public AreAccountsSelectedRuleTests()
        {
            // Arrange
            _validationRule = new AreAccountsSelectedRule { ValidationMessage = "Please select From and To Accounts both." };
            _moneyTransferViewModel = new ValidatableObject<MoneyTransferViewModel>() { Value = new MoneyTransferViewModel() };
            _moneyTransferViewModel.Validations.Add(_validationRule);
        }

        [Fact]
        public void AreAccountsSelectedRule_ReturnsTrue_WhenBoth_AccountsAreSelected()
        {
            // Arrange
            _moneyTransferViewModel.Value.FromAccount = new Account("userId", AccountType.Current, 1000);
            _moneyTransferViewModel.Value.ToAccount = new Account("userId", AccountType.Savings, 1000);

            // Act
            var result = _moneyTransferViewModel.Validate();

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void AreAccountsSelectedRule_ReturnsFalse_WhenOneOfThe_AccountsIsNotSelected()
        {
            // Arrange
            _moneyTransferViewModel.Value.FromAccount = new Account("userId", AccountType.Current, 1000);
            _moneyTransferViewModel.Value.ToAccount = null;

            // Act
            var result = _moneyTransferViewModel.Validate();

            // Assert
            Assert.False(result);
        }
    }
}

