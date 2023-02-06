using AccountManagement.ViewModels;
using AccountManagement.Views;
using Moq;
using Xunit;

namespace AccountManagement.Tests.ViewModels
{
    public class LoginViewModelTests : BaseTests
    {
		private readonly LoginViewModel _viewModel;

        public LoginViewModelTests()
		{
            // Arrange
            _viewModel = new LoginViewModel(MockUserService.Object, MockAccountsService.Object,
                MockDialogService.Object, MockNavigationService.Object);
        }

        [Fact]
        public void LogIn_IsSuccessful_ForValidUser()
        {
            // Arrange
            _viewModel.UserName.Value = MockUserService?.Object?.GetUsers()?.FirstOrDefault()?.UserName;

            // Act
            _viewModel.LogInCommand.Execute(this);

            // Assert
            Assert.True(_viewModel.UserName.IsValid);
            MockNavigationService.Verify(navigationService => navigationService.PushAsRoot(It.IsAny<AccountsView>()), Times.Once);
        }

        [Fact]
        public void LogIn_Fails_ForInValidUser()
        {
            // Arrange
            _viewModel.UserName.Value = "invalidUserName";

            // Act
            _viewModel.LogInCommand.Execute(this);

            // Assert
            Assert.False(_viewModel.UserName.IsValid);
            MockDialogService.Verify(dialogService => dialogService.ShowAlertAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()), Times.Once);
        }
    }
}

