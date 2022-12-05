using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tourism_1.Models;
using Tourism_1.Services;

namespace Tourism_1.Controllers
{
    [AllowAnonymous]
    public class UserController : Controller
    {
        UserdataAccess userdata;
        TourismEntities5 context;
        

        public UserController()
        {
            userdata = new UserdataAccess();
            context = new TourismEntities5();

        }



        public ActionResult Signup()
        {
            User user = new User();
            return View(user);
        }

        [HttpPost]
        public ActionResult Signup(User user)
        {
            user.RoleId = 2;
            var usersName = (from users in userdata.GetAllUser() where user.UserName ==users.UserName select users).ToList();
            var userEmail = (from users in userdata.GetAllUser() where user.UserEmail == users.UserEmail select users).ToList();
            var userMobile = (from users in userdata.GetAllUser() where user.UserMobile == users.UserMobile select users).ToList();
            if(userEmail.Count()>0)
            {
                ViewBag.RegisterEmail = "EMAIL ALREADY EXIST ";
                return View();

            }
            if(userMobile.Count()>0)
            {
                ViewBag.RegisterMobile = "MOBILE NO. ALREADY EXIST ";
                return View();

            }
            if (usersName.Count() > 0)
            {
                ViewBag.RegisterName = "USERNAME ALREADY EXIST ";
                return View();
            }
            if (ModelState.IsValid)
            {

                
                userdata.Create(user);
                
                return RedirectToAction("Login", "Account");
              }
            else
            {
                return View();
            }
        }
        public ActionResult HotelSignup()
        {
            User user = new User();
            return View(user);
        }
        [HttpPost]
        public ActionResult HotelSignup(User user)
        {
            if(ModelState.IsValid)
            {
                user.RoleId = 3;
                userdata.Create(user);

                
                return RedirectToAction("Login", "Account");
            }
            else
            {
                return View();
            }
        }
        public JsonResult IsEmailAvailble(string UserEmail)
        { 
            return Json(userdata.GetAllUser().Any(x => x.UserEmail ==UserEmail), JsonRequestBehavior.AllowGet);
        }



    }
}