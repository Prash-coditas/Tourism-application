using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace Tourism_1.Models
{
    public class BookingData
    {
        public string Username { get; set; }
        public int Price { get; set; }
        public DateTime BookingDate { get; set; }

        public string HotelName { get; set; }
        public string CityName { get; set; }
        
    }
}