using System;
namespace AccountManagement.Services.Loan
{
	public interface IRatingBasedCalculator
	{
		int Calculate(AccountManagement.Models.Loan loan);
	}
}

