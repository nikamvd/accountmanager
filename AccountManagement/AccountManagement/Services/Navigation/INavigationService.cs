	using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AccountManagement.Services.Navigation
{
    public interface INavigationService
    {
        Task PushAsync(Page page);
        Task<bool> PushAsRoot(Page page);
    }
}

