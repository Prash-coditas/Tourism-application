using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tourism_1.Models;
using Tourism_1.Services;



namespace Tourism_1.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        UserdataAccess userdata;
        
        public HomeController()
        {
            userdata = new UserdataAccess();

        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Create()
        { 
            //User user = new User();
            return View();
        }
        [HttpPost]
        public ActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                user.RoleId = 2;
                userdata.Create(user);
                return RedirectToAction("Login", "Account");


            }
            else
            {
                return View();
            }
        }
        //[HttpGet]
        //[Authorize(Roles ="Admin")]
        //public ActionResult Get()
        //{
        //    var result = userdata.Create()Select(x => new Userdata()
        //    {
        //        UserId = x.UserId,
        //        UserName = x.UserName,
        //        UserEmail = x.UserEmail,
        //        UserMobile = x.UserMobile,
        //        BirthDate = x.BirthDate,
        //        UserAddress = x.UserAddress,
        //        Password=x.Password,
        //        RoleId=x.RoleId


        //    }).ToList();
 
        //    //if(User.Identity.Name=="Prashant")
        //    //{
        //    //    return View(result);
        //    //}
            
           
        //        return View(result);
            
            
        //}
    }
}