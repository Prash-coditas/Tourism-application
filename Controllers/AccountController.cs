using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tourism_1.Models;
using System.Web.Security;
using Tourism_1.Services;

namespace Tourism_1.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        UserdataAccess user;
        public AccountController()
        {
            user = new UserdataAccess();

        }
        // GET: Account
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Account account)
        {

           
                bool isValid = user.GetAllUser().Any(x => x.UserName == account.UserName && x.Password == account.Password);
                if (isValid)
                 {
                    var id = (from user in user.GetAllUser()
                         where user.UserName == account.UserName
                         select user).Take(1);
                Session["hotel_id"] = id.ToList()[0].UserId;
                Session["id"] = id.ToList()[0].UserId;


                FormsAuthentication.SetAuthCookie(account.UserName,false);

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
            Session.Abandon();
            return RedirectToAction("Login");
        }
    }
}