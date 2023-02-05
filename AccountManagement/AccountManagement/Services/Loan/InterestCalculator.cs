using System;
using AccountManagement.Models;

namespace AccountManagement.Services.Loan
{
	public class InterestCalculator
	{
		private readonly IRatingBasedCalculator _ratingBasedCalculator;

        public InterestCalculator(IRatingBasedCalculator ratingBasedCalculator)
		{
			_ratingBasedCalculator = ratingBasedCalculator;
        }

		public int Calculate(AccountManagement.Models.Loan loan)
		{
			return _ratingBasedCalculator.Calculate(loan);
		}
	}
}

