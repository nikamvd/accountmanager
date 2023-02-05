using System;
using AccountManagement.Models;

namespace AccountManagement.Validations
{
	public class IsValidAmountRule : IValidationRule<Loan>
    {
        public string ValidationMessage { get; set; }

        public bool Check(Loan value)
        {
            if (value.Amount > 0 && value.Amount <= 10000)
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

