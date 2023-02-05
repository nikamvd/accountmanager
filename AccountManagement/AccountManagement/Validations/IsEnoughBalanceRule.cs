using System;
using AccountManagement.ViewModels;

namespace AccountManagement.Validations
{
    public class IsEnoughBalanceRule : IValidationRule<MoneyTransferViewModel>
    {
        public string ValidationMessage { get; set; }

        public bool Check(MoneyTransferViewModel value)
        {
            if (value.AmountToTransfer <= value.FromAccount?.Balance)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

