using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tourism_1.Models;
using Tourism_1.Services;

namespace Tourism_1.Controllers
{
    public class TourGuideController : Controller
    {
        // GET: TourGuide
        TourGuideAccess tourGuide;
        CityAddAccess citydata;
        public TourGuideController()
        {
            tourGuide = new TourGuideAccess();
            citydata = new CityAddAccess();
        }
        public ActionResult GetAllTourGuides()
        {
            var all_guides = tourGuide.GetAllTourGuides().ToList();
            //var id = from guide in all_guides
            //         select guide.CityId;
            List<City> cities = new List<City>();
            foreach(var item in all_guides)
            {
                cities.Add(citydata.GetCityById(item.CityId));
            }
            ViewBag.cities = cities;




            
            return View(all_guides);
        }
        public ActionResult Add_TourGuide()
        {
            var tourguide = new TourGuide();
            List<Models.City> cities = citydata.GetAllCities().ToList();
            ViewBag.citylist = new SelectList(cities, "CityId", "CityName");
            return View(tourguide);
        }
        [HttpPost]
        public ActionResult Add_TourGuide(TourGuide tourguide)
        {
            tourGuide.Create(tourguide);
            return RedirectToAction("GetAllTourGuides", "TourGuide");
        }
        public ActionResult Edit(int id)
        {
            
            
                var tourguide = tourGuide.GetTourGuideById(id);
                List<City> cities = citydata.GetAllCities().ToList();
                ViewBag.citiess = new SelectList(cities, "CityId", "CityName");
                return View(tourguide);
            
           
            
        }
        [HttpPost]
        public ActionResult Edit(int id, TourGuide tourguide)
        {
            tourGuide.UpdateTourGuide(id, tourguide);
            return RedirectToAction("GetAllTourGuides", "TourGuide");
        }

        public void GetCity(int id)
        {
            var city = (from cit in citydata.GetAllCities()
                       where cit.CityId == id
                       select cit   .CityName).ToString();
            ViewBag.city_name = city;
            
        }

    }
}