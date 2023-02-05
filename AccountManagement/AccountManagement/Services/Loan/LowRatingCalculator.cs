using System;
namespace AccountManagement.Services.Loan
{
	public class LowRatingCalculator : IRatingBasedCalculator
    {
        public int Calculate(AccountManagement.Models.Loan loan)
        {
            int interest = 0;
            switch(loan.Duration)
            {
                case 1:
                    interest = loan.Amount * 20 * 1 / 100;
                    break;
                case 3:
                    interest = loan.Amount * 15 * 3 / 100;
                    break;
                case 5:
                    interest = loan.Amount * 10 * 5 / 100;
                    break;
            }
            return interest;
        }
    }
}

