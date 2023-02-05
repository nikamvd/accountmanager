using System;
using System.Collections.Generic;
using AccountManagement.Models;
using AccountManagement.Services;
using System.Linq;

[assembly: Xamarin.Forms.Dependency(typeof(UserService))]
namespace AccountManagement.Services
{
	public interface IUserService
	{
		List<User> GetUsers();
        User GetUser(string userName);
    }

    public class UserService : IUserService
    {
        private readonly List<User> _users;

        public UserService()
		{
            _users = new List<User>()
            {
                new User("Bob", 15),
                new User("Jim", 45),
                new User("Anne", 80)
            };
        }

        public List<User> GetUsers()
        {
            return _users;
        }

        public User GetUser(string userName)
        {
            return _users.Where(user => user.UserName == userName).FirstOrDefault();
        }
    }
}

