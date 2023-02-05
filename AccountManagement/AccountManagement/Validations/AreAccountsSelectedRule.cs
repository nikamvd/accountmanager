using System;
using AccountManagement.ViewModels;

namespace AccountManagement.Validations
{
    public class AreAccountsSelectedRule : IValidationRule<MoneyTransferViewModel>
    {
        public string ValidationMessage { get; set; }

        public bool Check(MoneyTransferViewModel value)
        {
            if (value.FromAccount != null && value.ToAccount != null)
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

