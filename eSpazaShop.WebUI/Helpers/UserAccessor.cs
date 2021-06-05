using eSpazaShop.Entities;
using eSpazaShop.WebUI.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eSpazaShop.WebUI.Helpers
{
    public class UserAccessor: IUserAccessor
    {
        private readonly UserManager<User> _userManager;
        private IHttpContextAccessor _httpContextAccessor;
        public UserAccessor(UserManager<User> userManager, IHttpContextAccessor httpContextAccessor)
        {
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }
        
        public User GetUser()
        {
            //method fetches all user details from the database
            if (_httpContextAccessor.HttpContext.User != null)
                return _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User).Result;
            else
                return null;
        }
    }
}
