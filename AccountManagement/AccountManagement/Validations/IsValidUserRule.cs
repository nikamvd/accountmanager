using System;
using System.Collections.Generic;
using System.Linq;
using AccountManagement.Models;
using AccountManagement.Services;
using Xamarin.Forms;

namespace AccountManagement.Validations
{
    public class IsValidUserRule : IValidationRule<string>
    {
        private readonly IUserService _userService;
        public IsValidUserRule(IUserService userService = null)
        {
            _userService = userService ?? DependencyService.Get<IUserService>();
        }

        public string ValidationMessage { get; set; }

        public bool Check(string value)
        {
            var users = _userService.GetUsers();
            if(users.Any(user => user.UserName == value))
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

