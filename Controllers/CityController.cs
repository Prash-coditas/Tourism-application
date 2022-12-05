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
    public class CityController : Controller
    {
        CityAddAccess citydata;
        PlaceDataAccess placedata;
        TourGuideAccess tourdata;

        public CityController()
        {
            citydata = new CityAddAccess();
            placedata = new PlaceDataAccess();
            tourdata = new TourGuideAccess();

        }
        public ActionResult Add_New_City()
        {
            var city = new City();
            return View(city);
        }
        [HttpPost]
        public ActionResult Add_New_City(City city)
        {
           citydata.Create(city);
            return RedirectToAction("GetCities","City");
        }
        public ActionResult GetCities()
        {
            var cities = citydata.GetAllCities().ToList();
            return View(cities);
        }
        public ActionResult Edit(int id)
        {
            var city = citydata.GetCityById(id);
            return View(city);
        }
        [HttpPost]
        public ActionResult Edit(int id,City city)
        {
            citydata.UpdateCity(id, city);
            return RedirectToAction("GetCities","City");
        }
        public ActionResult Details(int id)
        {
            var city_data = citydata.GetCityById(id);
            return View(city_data);
        }
       
        public ActionResult Search()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Search(string city)
        {
            ViewBag.CityName = city;
            
            if (city == null)
            {
                return View();
            }
            else
            {
                var result = (from place in placedata.GetAllPlaces()
                              join cit in citydata.GetAllCities()  on place.CityId equals cit.CityId

                              where cit.CityName == city
                              select place);

                return View(result);

            }
            

        }
        public ActionResult Search2(int? id)
        {
            return RedirectToAction("Data", "Package");
        }
        public ActionResult Search1(string city)
        {
            if (city == null)
            {
                return View();
            }
            else
            {
                var result = (from tourguide in tourdata.GetAllTourGuides()
                              join cit in citydata.GetAllCities() on tourguide.CityId equals cit.CityId

                              where cit.CityName == city
                              select tourguide);

                return View(result);

            }

        }
    }
}