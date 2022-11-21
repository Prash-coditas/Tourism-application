using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tourism_1.Models;
using System.Web.Security;

namespace Tourism_1.Controllers
{
    public class AccountController : Controller
    {
        TourismEntities tourismEntities;
        public AccountController()
        {
            tourismEntities = new TourismEntities();

        }
        // GET: Account
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Account account)
        {
            bool isValid = tourismEntities.Users.Any(x => x.UserName == account.UserName && x.Password == account.Password);
            if(isValid)
            {
                FormsAuthentication.SetAuthCookie(account.UserName, false);

                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("", "Invalid username and password");
                return View();
            }
            

        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}