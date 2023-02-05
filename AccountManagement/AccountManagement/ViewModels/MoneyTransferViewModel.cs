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
    public class MoneyTransferViewModel : ViewModelBase
    {
        private Account _fromAccount;
        private Account _toAccount;

        public MoneyTransferViewModel()
		{
		}

        public Account FromAccount
        {
            get => _fromAccount;
            set
            {
                _fromAccount = value;
                RaisePropertyChanged(() => FromAccount);
            }
        }

        public Account ToAccount
        {
            get => _toAccount;
            set
            {
                _toAccount = value;
                RaisePropertyChanged(() => ToAccount);
            }
        }

        private int _amountToTransfer;
        public int AmountToTransfer
        {
            get => _amountToTransfer;
            set
            {
                _amountToTransfer = value;
                RaisePropertyChanged(() => AmountToTransfer);
            }
        }
    }
}

