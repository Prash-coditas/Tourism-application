using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tourism_1.Services;
using Tourism_1.Models;

namespace Tourism_1.Controllers
{
    public class PlaceController : Controller
    {
        PlaceDataAccess placedata;
        CityAddAccess citydata;
        public PlaceController()
        {
            placedata = new PlaceDataAccess();
            citydata = new CityAddAccess();

        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Places_by_city()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Places_by_city(string city)
        {
            var cities = citydata.GetAllCities();
            Session["all_cities"] = cities; 
            
            if (city == null || city.Length == 0)
            {
                //ModelState.AddModelError("", "Invalid username and password");
                return RedirectToAction("Index","Home");
            }


            else
            {
                city=char.ToUpper(city[0]) + city.Substring(1);
                bool isCityAvailable = cities.Any(x => x.CityName == city);
                if (isCityAvailable)
                {
                    Session["CityName"] = city;
                    int city_id = (from cit in citydata.GetAllCities()
                               where cit.CityName == city
                               select cit.CityId).FirstOrDefault();
                    Session["place_id"] = city_id;
                    var result = (from place in placedata.GetAllPlaces()
                                  join cit in cities on place.CityId equals cit.CityId

                                  where cit.CityName == city
                                  select place);


                    return View(result);
                }
                else
                {
                    
                    return RedirectToAction("NoCity");
                }

            }
        }
        public ActionResult NoCity()
        {
            return View();
        }
        public ActionResult AllActivities(int id)
        {
            var activities = (from places in placedata.GetAllPlaces()
                              where places.CityId == id
                              select places).ToList();


            return View(activities);
        }
        public ActionResult SeePlaces(int id)
        {
            string city = citydata.GetCityById(id).CityName;
            return RedirectToAction("Places_by_city","Place", new { city = city });
        }
        public ActionResult All_Places()
        {
            var all_places = placedata.GetAllPlaces();
            //List<Models.City> cities = citydata.GetAllCities().ToList();
            //ViewBag.citiesForPlaces = new SelectList(cities, "CityId", "CityName");
            return View(all_places);
        }
        public ActionResult Add_Place()
        {

            var place = new places_in_city();
            List<Models.City> cities = citydata.GetAllCities().ToList();
            ViewBag.citiesForPlace = new SelectList(cities, "CityId", "CityName");
            return View(place);
        }
    }
}