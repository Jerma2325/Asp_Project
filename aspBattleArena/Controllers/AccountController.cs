using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using aspBattleArena.Views;
namespace aspBattleArena.Controllers;

 
    public class AccountController : Controller  
    {
        public AccountController()
        {
        }

        public IActionResult Login()  
        {  
            return View();  
        }  
  
        [HttpPost]  
        public IActionResult Login(string userName, string password)  
        {  
            if(!string.IsNullOrEmpty(userName) && string.IsNullOrEmpty(password))  
            {  
                return RedirectToAction("Login");  
            }  
            
            ClaimsIdentity identity = null;  
            bool isAuthenticated = false;  
  
            if (userName == "Admin" && password == "password")  
            {  
  
                identity = new ClaimsIdentity(new[] {  
                    new Claim(ClaimTypes.Name, userName),  
                    new Claim(ClaimTypes.Role, "Admin")  
                }, CookieAuthenticationDefaults.AuthenticationScheme);  
  
                isAuthenticated = true;  
            }  
  
            if (userName == "User" && password == "password")  
            {  
                //Create the identity for the user  
                identity = new ClaimsIdentity(new[] {  
                    new Claim(ClaimTypes.Name, userName),  
                    new Claim(ClaimTypes.Role, "User")  
                }, CookieAuthenticationDefaults.AuthenticationScheme);  
  
                isAuthenticated = true;  
            }  
  
            if (isAuthenticated)  
            {  
                var principal = new ClaimsPrincipal(identity);  
  
                var login = HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);  
  
                return RedirectToAction("Index", "Home");  
            }  
            return View();  
            
        }
        [HttpPost]  
        public IActionResult Logout()  
        {  
            var login = HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);  
            return RedirectToAction("Login");  
        } 
    }  
