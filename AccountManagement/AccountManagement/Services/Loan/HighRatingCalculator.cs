using System;
namespace AccountManagement.Services.Loan
{
	public class HighRatingCalculator : IRatingBasedCalculator
    {
        public int Calculate(AccountManagement.Models.Loan loan)
        {
            int interest = 0;
            switch (loan.Duration)
            {
                case 1:
                    interest = loan.Amount * 12 * 1 / 100;
                    break;
                case 3:
                    interest = loan.Amount * 8 * 3 / 100;
                    break;
                case 5:
                    interest = loan.Amount * 5 * 5 / 100;
                    break;
            }
            return interest;
        }
    }
}

