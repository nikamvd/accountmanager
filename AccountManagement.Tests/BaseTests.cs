using System;
using AccountManagement.Models;
using AccountManagement.Services;
using AccountManagement.Services.Dialog;
using AccountManagement.Services.Navigation;
using Moq;
using Xamarin.Forms;
using Xamarin.Forms.Mocks;
using Xunit.Abstractions;

namespace AccountManagement.Tests
{
    public abstract class BaseTests
    {
        static BaseTests()
        {
            MockForms.Init();
            Application.Current = new App(MockUserService.Object, MockAccountsService.Object,
                MockDialogService.Object, MockNavigationService.Object);
        }

        static object lockObject = new object();

        static internal Mock<IUserService> mockUserService;
        protected static internal Mock<IUserService> MockUserService
        {
            get
            {
                if (mockUserService == null)
                {
                    lock (lockObject)
                    {
                        if (mockUserService == null)
                        {
                            mockUserService = GetMockUserService();
                        }
                    }
                }
                return mockUserService;
            }
        }

        private static Mock<IUserService> GetMockUserService()
        {
            var mock = new Mock<IUserService>();

            User user = new User("Jim", 45);
            mock.Setup(x => x.GetUser(It.IsAny<string>()))
                .Returns(user);

            mock.Setup(x => x.GetUsers())
                .Returns(new List<User>() { user });

            return mock;
        }

        static internal Mock<IDialogService> mockDialogService;
        protected static internal Mock<IDialogService> MockDialogService
        {
            get
            {
                if (mockDialogService == null)
                {
                    lock (lockObject)
                    {
                        if (mockDialogService == null)
                        {
                            mockDialogService = GetMockDialogService();
                        }
                    }
                }
                return mockDialogService;
            }
        }

        private static Mock<IDialogService> GetMockDialogService()
        {
            var mock = new Mock<IDialogService>();
            return mock;
        }

        static internal Mock<INavigationService> mockNavigationService;
        protected static internal Mock<INavigationService> MockNavigationService
        {
            get
            {
                if (mockNavigationService == null)
                {
                    lock (lockObject)
                    {
                        if (mockNavigationService == null)
                        {
                            mockNavigationService = GetMockNavigationService();
                        }
                    }
                }
                return mockNavigationService;
            }
        }

        private static Mock<INavigationService> GetMockNavigationService()
        {
            var mock = new Mock<INavigationService>();
            return mock;
        }

        static internal Mock<IAccountsService> mockAccountsService;
        protected static internal Mock<IAccountsService> MockAccountsService
        {
            get
            {
                if (mockAccountsService == null)
                {
                    lock (lockObject)
                    {
                        if (mockAccountsService == null)
                        {
                            mockAccountsService = GetMockAccountsService();
                        }
                    }
                }
                return mockAccountsService;
            }
        }

        private static Mock<IAccountsService> GetMockAccountsService()
        {
            var mock = new Mock<IAccountsService>();
            mock.Setup(x => x.GetAccounts(It.IsAny<User>()))
                .Returns(new List<Account>() { new Account("userId", AccountType.Current, 1000) });
            return mock;
        }
    }
}

