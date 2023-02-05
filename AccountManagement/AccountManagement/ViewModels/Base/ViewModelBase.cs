using System;
using AccountManagement.Services.Dialog;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;
using AccountManagement.Services.Navigation;

namespace AccountManagement.ViewModels.Base
{
    public abstract class ViewModelBase : ExtendedBindableObject
    {
        protected readonly IDialogService DialogService;
        protected readonly INavigationService NavigationService;

        public ViewModelBase(
            IDialogService dialogService = null,
            INavigationService navigationService = null)
        {
            DialogService = dialogService ?? DependencyService.Get<IDialogService>();
            NavigationService = navigationService ?? DependencyService.Get<INavigationService>();
        }
    }
}

