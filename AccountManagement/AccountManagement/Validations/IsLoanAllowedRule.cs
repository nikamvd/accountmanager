using System;
using AccountManagement.Models;

namespace AccountManagement.Validations
{
	public class IsLoanAllowedRule : IValidationRule<Loan>
    {
        private readonly int _creaditRating;
        public IsLoanAllowedRule(int creditRating)
        {
            _creaditRating = creditRating;
        }

        public string ValidationMessage { get; set; }

        public bool Check(Loan value)
        {
            if (_creaditRating >= 20)
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

