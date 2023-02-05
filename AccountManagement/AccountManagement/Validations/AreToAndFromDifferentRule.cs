using System;
using AccountManagement.ViewModels;

namespace AccountManagement.Validations
{
    public class AreToAndFromDifferentRule : IValidationRule<MoneyTransferViewModel>
    {
        public string ValidationMessage { get; set; }

        public bool Check(MoneyTransferViewModel value)
        {
            if (value.FromAccount?.AccountId != value.ToAccount?.AccountId)
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

