using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tourism_1.Models;
using Tourism_1.Services;

namespace Tourism_1.Controllers
{
    public class City1Controller : Controller
    {
        // GET: City1
        CityAddAccess citydata;
        public City1Controller()
        {
            citydata = new CityAddAccess();
        }
        //public ActionResult Index()
        //{
        //    return View();
        //}
        public ActionResult Add_New_City()
        {
            var city = new City();
            return View(city);
        }
        [HttpPost]
        public ActionResult Add_New_City(City city)
        {
            citydata.Create(city);
            return View();
        }
    }
}