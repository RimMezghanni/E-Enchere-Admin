using E_Enchere_Admin.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace E_Enchere_Admin.Controllers
{
    public class AccountController : Controller
    {
        private readonly EEnchereContext _db;

        public AccountController(EEnchereContext db)
        {
            _db = db;

        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();

        }
        //login
        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            List<Admin> allAdmins = _db.Admins.ToList();

            ClaimsIdentity identity = null;
            bool isAuthenticate = false;

            if (string.IsNullOrEmpty(username) && string.IsNullOrEmpty(password))
            {
                return RedirectToAction("Login");
            }

            //if (username == "admin" && password == "admin")
            //{
            //    identity = new ClaimsIdentity(new[]{
            //        new Claim(ClaimTypes.Name,username),
            //         new Claim(ClaimTypes.PrimarySid,"1"),
            //        new Claim(ClaimTypes.Role,"Admin")
            //    }, CookieAuthenticationDefaults.AuthenticationScheme);
            //    isAuthenticate = true;
            //}

            else
            {
                foreach (Admin element in allAdmins)
                {
                    if (username == element.PrénomAdmin && password == element.MotDePasse)
                    {
                        identity = new ClaimsIdentity(new[]{
                            new Claim(ClaimTypes.Name,username),
                             new Claim(ClaimTypes.PrimarySid,"1"),
                            new Claim(ClaimTypes.Role,"User")
                            }, CookieAuthenticationDefaults.AuthenticationScheme);
                        isAuthenticate = true;
                        HttpContext.Session.SetString("username", username);
                        break;
                    }

                }

            }

            if (isAuthenticate)
            {
                var principal = new ClaimsPrincipal(identity);
                var login = HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
                TempData["data"] = username;
                return RedirectToAction("Index", "Home");
               
                //else
                //{

                //    return RedirectToAction("Index", "Rooms");
                //}


            }



            return View();

        }
        //Logout
        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("username");
            TempData["data"] = null;
            return View();
        }

    }
       
}