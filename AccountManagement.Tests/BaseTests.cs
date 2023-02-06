using System;
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
        }
    }
}

