using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tourism_1.Services;
using Tourism_1.Models;

namespace Tourism_1.Controllers
{
    public class HotelController : Controller
    {
        // GET: Hotel
        HotelDataAccess hoteldata;
        CityAddAccess citydata;
        UserdataAccess userdata;
        Packagedataaccess packagedata;
        TourismEntities5 context;
        public HotelController()
        {
            hoteldata = new HotelDataAccess();
            citydata = new CityAddAccess();
            userdata = new UserdataAccess();
            packagedata = new Packagedataaccess();
            context = new TourismEntities5();

        }


        public ActionResult Add_Hotel()
        {
            var hotel = new Hotel();
            List<Models.City> cities = citydata.GetAllCities().ToList();
            ViewBag.citylist = new SelectList(cities, "CityId", "CityName");

            return View();
        }
        [HttpPost]
        public ActionResult Add_Hotel(Hotel hotel)
        {
            if (ModelState.IsValid)
            {
                hotel.Status = -1;
                hotel.UserId = Convert.ToInt32(Session["hotel_id"]);
                //TempData.Keep("hotel_id");
                hoteldata.Create(hotel);
                return RedirectToAction("GetAllHotels", "Hotel");

            }
            else
            {
                return View();
            }
        }
        public ActionResult Edit(int id)
        {
            var hotel = hoteldata.GetHotelById(id);
            List<City> cities = citydata.GetAllCities().ToList();
            ViewBag.citiesdata = new SelectList(cities, "CityId", "CityName");
            return View(hotel);
        }
        [HttpPost]
        public ActionResult Edit(int id, Hotel hotel)
        {
            hoteldata.UpdateHotel(id, hotel);
            return RedirectToAction("GetAllHotels", "Hotel");
        }

        public ActionResult GetAllHotels()
        {
            int user_id = Convert.ToInt32(Session["hotel_id"]);


            var hotels = (from hotel in hoteldata.GetAllHotels()
                          where hotel.UserId == user_id
                          select hotel).ToList();
            return View(hotels);


        }
        public ActionResult RegisteredHotels()
        {
            var hotels = hoteldata.GetAllHotels().Where(st => st.Status == null);
            return View(hotels);
        }
        public ActionResult UnregisteredHotel()
        {
            var hotels = hoteldata.GetAllHotels().Where(st => st.Status == -1);
            return View(hotels);
        }
        public ActionResult RejectHotel(int id)
        {
             hoteldata.Delete(id);

            return RedirectToAction("UnregisteredHotel");
        }
        public ActionResult ApproveHotel(int id)
        {
            var hotel = context.Hotels.Find(id);
            hotel.Status = null;
            context.SaveChanges();
            
            return RedirectToAction("UnregisteredHotel");
        }
        public ActionResult GetAllCustomers(int id)
        {

            var packages = (from package in packagedata.GetAllPackage()
                            where package.Hotel_id == id
                            select package).Distinct();
            if (packages.Count()==0)
            {
                return View();
            }
            else
            {

                var all_customers = (from user in userdata.GetAllUser()
                                     join package in packages on user.UserId equals package.User_id
                                     where user.UserId == package.User_id
                                     select user).ToList();
                return View(all_customers);
            }
          
        }
        public ActionResult NoCustomerForHotel()
        {
            return View();
        }
        







    }

        
        

    
}