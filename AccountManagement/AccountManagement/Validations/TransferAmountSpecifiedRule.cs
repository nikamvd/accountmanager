using System;
using AccountManagement.ViewModels;

namespace AccountManagement.Validations
{
    public class TransferAmountSpecifiedRule : IValidationRule<MoneyTransferViewModel>
    {
        public string ValidationMessage { get; set; }

        public bool Check(MoneyTransferViewModel value)
        {
            if (value.AmountToTransfer > 0)
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

