using System;
namespace AccountManagement.Models
{
	public class User
	{
		public User(string userName, int creditRating)
		{
            UserId = Guid.NewGuid().ToString("N");
			UserName = userName;
			CreditRating = creditRating;
        }

		public string UserId { get; }
		public string UserName { get; set; }
		public int CreditRating { get; set; }
	}
}