using eSpazaShop.Entities;
using eSpazaShop.Services.Interfaces;
using eSpazaShop.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eSpazaShop.WebUI.Controllers
{
    public class AccountController : Controller
    {
        //hook the authenication services by injecting it
        /// <summary>
        /// Here we use IOC design to apply methods or properties that are not defined inside the project 
        /// Add to services
        /// services.AddScoped<IAuthenticationService,AuthenticationService>(); 
        /// </summary>
        public IAuthenticationService _authenticationService;

        public AccountController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(LoginModel model ,string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var user = _authenticationService.AuthenticateUser(model.Email, model.Password);
                if (user!=null)
                {
                    //AccountController decides which view to render pending on previleges of users
                    if (!String.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                        return Redirect(returnUrl);

                    if (user.Roles.Contains("Admin"))
                    {
                        return RedirectToAction("Index", "Dashboard", new { area = "Admin" });
                    }
                    else if (user.Roles.Contains("User"))
                    {
                        return RedirectToAction("Index", "Dashboard", new { area = "User" });
                    }

                }

            }
            return View();
        }
        public IActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SignUp(UserModel model)
        {
            if (ModelState.IsValid)
            {
                User _user = new User
                {
                    Name = model.Name,
                    UserName = model.Email,
                    Email = model.Email,
                    PhoneNumber = model.PhoneNumber
                };
                //call login methods in services
                bool result = _authenticationService.CreateUser(_user, model.Password);
                if (result)
                {
                    RedirectToAction("Login");
                }
            }
            return View();
        }
        //sign out has a different implementation because it takes time to clear the cookie with user details
        //SignOut asks to hide the method changed method to Logout SignOutComplete
        public async Task <IActionResult> LogOut()
        {
            await _authenticationService.SignOut();
            return RedirectToAction("LogOutComplete");
        }
        public IActionResult LogOutComplete()
        {
            return View();
        }
    }
}
