using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tourism_1.Models;
using Tourism_1.Services;


namespace Tourism_1.Controllers
{
    public class PackageController : Controller
    {
        Package_Information infromationn;
        UserdataAccess userdata;
        HotelDataAccess hoteldata;
        TransportationDataAccess transportationdata;
        TourGuideAccess tourGuidedata;
        CityAddAccess citydata;
        Packagedataaccess packagedata;
        PaymentDataAccess paymentdata;

        public PackageController()
        {
            infromationn = new Package_Information();
            userdata = new UserdataAccess();
            hoteldata = new HotelDataAccess();
            transportationdata = new TransportationDataAccess();
            tourGuidedata = new TourGuideAccess();
            citydata = new CityAddAccess();
            packagedata = new Packagedataaccess();
            paymentdata = new PaymentDataAccess();

        }

        public ActionResult GetPackages()
        {
            return View();
        }
        public ActionResult ShowPackages()
        
        
        {
            string city = Convert.ToString(Session["CityName"]);
            if (city==null)
            {
                return View();
            }
            else
            {
                int cityId = (from cit in citydata.GetAllCities()
                              where cit.CityName == city
                              select cit.CityId).FirstOrDefault();
                Session["cityidd"] = cityId;
                var highly_costly_transportations = transportationdata.GetAllTransportation().Where(id => id.CityId == cityId).OrderByDescending(price => price.TicketPrice).FirstOrDefault();
                var less_costly_transporations = transportationdata.GetAllTransportation().Where(id => id.CityId == cityId).OrderBy(price => price.TicketPrice).FirstOrDefault();
                var highly_costly_tourguide = tourGuidedata.GetAllTourGuides().Where(id => id.CityId == cityId).OrderByDescending(price => price.Charges).FirstOrDefault();
                var less_costly_tourguide = tourGuidedata.GetAllTourGuides().Where(id => id.CityId == cityId).OrderBy(price => price.Charges).FirstOrDefault();
                var highly_costly_hotel = hoteldata.GetAllHotels().Where(id => id.Cityid == cityId).Where(st=>st.Status==null).OrderByDescending(price => price.Hotelrentperday).FirstOrDefault();
                var less_costly_hotel = hoteldata.GetAllHotels().Where(id => id.Cityid == cityId).Where(st => st.Status == null).OrderBy(price => price.Hotelrentperday).FirstOrDefault();
                Package_Information cheaper = new Package_Information();
                cheaper.Transportation_id = less_costly_transporations.TrasnportationId;
                cheaper.Transportation_name = less_costly_transporations.TransportationName;
                cheaper.No_of_days = 4;
                cheaper.Package_id = 1;
                cheaper.Guide_id = less_costly_tourguide.GuideId;
                cheaper.Guide_name = less_costly_tourguide.GuideName;
                cheaper.Guide_mobile = less_costly_tourguide.GuideMobile;
                cheaper.hotel_id = less_costly_hotel.HotelId;
                cheaper.Hotel_Address = less_costly_hotel.HotelAddress;
                cheaper.Hotel_name = less_costly_hotel.HotelName;
                cheaper.cityid = cityId;
                cheaper.Price = less_costly_transporations.TicketPrice + (less_costly_tourguide.Charges + less_costly_hotel.Hotelrentperday) * 4 + 3000;

                Package_Information budget_friendly = new Package_Information();
                budget_friendly.Package_id = 2;
                budget_friendly.cityid = cityId;
                budget_friendly.No_of_days = 3;
                budget_friendly.Transportation_id = highly_costly_transportations.TrasnportationId;
                budget_friendly.Transportation_name = highly_costly_transportations.TransportationName;
                budget_friendly.Guide_id = highly_costly_tourguide.GuideId;
                budget_friendly.Guide_name = highly_costly_tourguide.GuideName;
                budget_friendly.Guide_mobile = highly_costly_tourguide.GuideMobile;
                budget_friendly.hotel_id = less_costly_hotel.HotelId;
                budget_friendly.Hotel_name = less_costly_hotel.HotelName;
                budget_friendly.Hotel_Address = less_costly_hotel.HotelAddress;
                budget_friendly.Price = highly_costly_transportations.TicketPrice + (highly_costly_tourguide.Charges + less_costly_hotel.Hotelrentperday) * 3 + 2000;

                Package_Information highest_costly_package = new Package_Information();
                highest_costly_package.Package_id = 3;
                highest_costly_package.cityid = cityId;
                highest_costly_package.No_of_days = 3;
                highest_costly_package.Transportation_id = highly_costly_transportations.TrasnportationId;
                highest_costly_package.Transportation_name = highly_costly_transportations.TransportationName;
                highest_costly_package.Guide_id = highly_costly_tourguide.GuideId;
                highest_costly_package.Guide_name = highly_costly_tourguide.GuideName;
                highest_costly_package.Guide_mobile = highly_costly_tourguide.GuideMobile;
                highest_costly_package.hotel_id = highly_costly_hotel.HotelId;
                highest_costly_package.Hotel_name = highly_costly_hotel.HotelName;
                highest_costly_package.Hotel_Address = highly_costly_hotel.HotelAddress;
                highest_costly_package.Price = highly_costly_transportations.TicketPrice + (highly_costly_tourguide.Charges + highly_costly_hotel.Hotelrentperday) * 3 + 3000;
                Package_Information.data.Clear();
                Package_Information.data.Add(cheaper);
                Package_Information.data.Add(budget_friendly);
                Package_Information.data.Add(highest_costly_package);
                return View(Package_Information.data);
             }
            
        }

        public ActionResult Packages(int? packageid)
        {
            return RedirectToAction("UserPackage", new {packageid=packageid});
        }

        public ActionResult TotalPackages()
        {
            var packages = Package_Information.data.ToList();
            return View(packages);
        }
        public ActionResult PackageDetails(int id)
        {
            Session["this_id"] = id;
            var list_of_packages = Package_Information.data.ToList();
            var package_data = (from package in list_of_packages
                               where package.Package_id == id
                               select package).FirstOrDefault();
            return View(package_data);
    }
        public ActionResult EditPackage(int packageid)
        {
            var list_of_packages = Package_Information.data.ToList();
            var package_data = (from package in list_of_packages
                                where package.Package_id == packageid
                                select package).FirstOrDefault();
            var cityid = package_data.cityid;
            var transportations = (from transport in transportationdata.GetAllTransportation()
                                  where transport.CityId == cityid
                                  select transport).ToList();
            
            var hotels = (from hotel in hoteldata.GetAllHotels()
                          where(hotel.Cityid == cityid && hotel.Status == null)
                          select hotel).ToList();
            ViewBag.AllTransportaions = transportations;

            //ViewBag.AllTourGuides = new SelectList(tourguides);

            ViewBag.AllHotels = hotels;
            

            return View(package_data);


        }

        [HttpPost]
        public ActionResult EditPackage(int packageid,Package_Information information)
        {
            Package_Information package = new Package_Information();
            var transportation = (from transport in transportationdata.GetAllTransportation()
                                     where transport.TransportationName == information.Transportation_name&& transport.CityId == Convert.ToInt32(Session["cityidd"])
                                     select transport).First();
            var package_data = Package_Information.data.ToList();
            var selected_package = (from data in package_data
                             where packageid == data.Package_id
                             select data).FirstOrDefault();
            var tourguide_id = selected_package.Guide_id;
            var tourguide = (from tourguides in tourGuidedata.GetAllTourGuides()
                             where tourguide_id == tourguides.GuideId
                             select tourguides).FirstOrDefault();

            var hotel_data = (from hotel in hoteldata.GetAllHotels()
                           where hotel.HotelName == information.Hotel_name && hotel.Cityid == Convert.ToInt32(Session["cityidd"])
                            select hotel).First();
      
            package.Package_id = packageid;
            package.Transportation_id = transportation.TrasnportationId;
            package.hotel_id = hotel_data.HotelId;
            package.cityid = Convert.ToInt32(Session["cityidd"]);
            package.No_of_days = information.No_of_days;
            package.Guide_id = selected_package.Guide_id;
            package.Price = transportation.TicketPrice + (hotel_data.Hotelrentperday + tourguide.Charges) *information.No_of_days+3000;
            package.Transportation_name = transportation.TransportationName;
            package.Guide_name = selected_package.Guide_name;
            package.Hotel_name = hotel_data.HotelName;
            package.Hotel_Address = hotel_data.HotelAddress;
            package.Guide_mobile = selected_package.Guide_mobile;
            
            Session["package"] = package;

            return RedirectToAction("PackageEditDetails","Package");
        }
        public ActionResult PackageEditDetails()
        {
            Package_Information information = new Package_Information();
            information = (Package_Information)Session["package"];
            
            return View(information);


        }

        public ActionResult Payment(int packageid)
        {
            Session["package_id"] = packageid;

            return View();
        }
        [HttpPost]
        public ActionResult Payment(Payment payment)
       {
            if (ModelState.IsValid)
            {
                payment.UserId = Convert.ToInt32(Session["id"]);
                paymentdata.Create(payment);
                Insert_In_Package(Convert.ToInt32(Session["package_id"]));
                
                return RedirectToAction("BookingDetails", "Package", new { id = Convert.ToInt32(Session["package_id_in_package"]) });
            }
            else
            {
                return View();
            }
        }
        public ActionResult PaymentAfterEdit(int packageid)
        {
            Session["package_id1"] = packageid;

            return View();
        }
        [HttpPost]
        public ActionResult PaymentAfterEdit(Payment payment)
        {
            int package_id = Convert.ToInt32(Session["package_id1"]);

            var package_last = packagedata.GetAllPackage().LastOrDefault();
            Package_Information package1 = new Package_Information();
            package1 = (Package_Information)Session["package"];
            package p2 = new package();
            if (package_last == null)
            {
                p2.PackageId = 1;
            }

            else
            {
                p2.PackageId = package_last.PackageId + 1;

            }
            payment.UserId = Convert.ToInt32(Session["id"]);
            p2.Transportation_id = package1.Transportation_id;
            p2.City_id = Convert.ToInt32(Session["cityidd"]);
            p2.Hotel_id = package1.hotel_id;
            p2.User_id = Convert.ToInt32(Session["id"]);
            p2.Package_price = package1.Price;
            p2.No_of_days = Convert.ToInt32(package1.No_of_days);
            p2.Guide_id = package1.Guide_id;
            p2.Tour_Start_Date = Convert.ToDateTime(Session["dates"]);

            paymentdata.Create(payment);
            packagedata.Create(p2);
           
            return RedirectToAction("BookingDetailsAfterEdit", "Package", new { id= p2.PackageId });

        }
        public void Insert_In_Package(int packageid)
        {
            var data1 = Package_Information.data.ToList();
            var package = packagedata.GetAllPackage().LastOrDefault();
            var package_id = 0;
            if (package == null)
            {
                package_id = 0;

            } else
            {
                package_id = package.PackageId+1;
                
            }
            Session["package_id_in_package"] = package_id;

            int idd = Convert.ToInt32(Session["id"]);
            package p1 = null;


            foreach (var item in data1)
            {

                if (packageid == item.Package_id)
                {
                    p1 = new package
                    {
                        Package_price = item.Price,
                        PackageId = package_id,
                        City_id = item.cityid,
                        Transportation_id = item.Transportation_id,
                        Guide_id = item.Guide_id,
                        Hotel_id = item.hotel_id,

                        User_id = idd,
                        No_of_days = Convert.ToInt32(item.No_of_days),
                        Tour_Start_Date = Convert.ToDateTime(Session["date"])
                    };
                }
            }
            packagedata.Create(p1);
            Package_Information.data.Clear();
        }
        [HttpPost]
        public ActionResult Get_Date(DateTime date)
        {
            Session["date"] = date;
            return RedirectToAction("PackageDetails", "Package",new { id =Convert.ToInt32(Session["this_id"]) });
        }
        public ActionResult GetDateAfterEdit(DateTime date)
        {
           
            Session["dates"] = date;
            return RedirectToAction("PackageEditDetails", "Package");
        }

        public ActionResult BookingDetails(int id)
        {
            var bookingdata = (from package in packagedata.GetAllPackage()
                               join city in citydata.GetAllCities() on package.City_id equals city.CityId
                               join hotel in hoteldata.GetAllHotels() on package.Hotel_id equals hotel.HotelId
                               join user in userdata.GetAllUser() on package.User_id equals user.UserId
                               where package.PackageId == id
                               select new BookingData()
                               {
                                   Username = user.UserName,
                                   Price = package.Package_price,
                                   BookingDate = Convert.ToDateTime(Session["date"]),
                                   HotelName = hotel.HotelName,
                                   CityName = city.CityName


                               }).FirstOrDefault();


            return View(bookingdata);

        }
        public ActionResult BookingDetailsAfterEdit(int id)
        {
            var bookingdata = (from package in packagedata.GetAllPackage()
                               join city in citydata.GetAllCities() on package.City_id equals city.CityId
                               join hotel in hoteldata.GetAllHotels() on package.Hotel_id equals hotel.HotelId
                               join user in userdata.GetAllUser() on package.User_id equals user.UserId
                               where package.PackageId == id
                               select new BookingData()
                               {
                                   Username = user.UserName,
                                   Price = package.Package_price,
                                   BookingDate = Convert.ToDateTime(Session["dates"]),
                                   HotelName = hotel.HotelName,
                                   CityName = city.CityName


                               }).FirstOrDefault();
            
            return View(bookingdata);

        }
    }
}