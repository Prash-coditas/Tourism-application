using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tourism_1.Models;

namespace Tourism_1.Controllers
{
    //[Authorize]
    public class UserController : Controller
    {
        TourismEntities tourismEntities;
        public UserController()
        {
            tourismEntities = new TourismEntities();

        }



        public ActionResult Signup()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Signup(User user)
        {
            if(ModelState.IsValid)
            {
                tourismEntities.Users.Add(user);
                tourismEntities.SaveChanges();
                return RedirectToAction("Login", "Account");


            }
            else
            {
                return RedirectToAction("Signup");
            }
           



        }
    }
}