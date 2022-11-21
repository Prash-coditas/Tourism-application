using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tourism_1.Models;



namespace Tourism_1.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        TourismEntities tourismEntities;
        public HomeController()
        {
            tourismEntities = new TourismEntities();

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
        [HttpGet]
        public ActionResult Get()
        {
            var result = tourismEntities.Users.Select(x => new Userdata()
            {
                UserId = x.UserId,
                UserName = x.UserName,
                UserEmail = x.UserEmail,
                UserMobile = x.UserMobile,
                BirthDate = x.BirthDate,
                UserAddress = x.UserAddress,
                Password=x.Password,
                RoleId=x.RoleId


            }).ToList();
 
            ;
            return View(result);
        }
    }
}