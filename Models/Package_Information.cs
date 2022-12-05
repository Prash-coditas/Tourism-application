using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tourism_1.Models
{
    public class Package_Information
    {
        public int Package_id { get; set; }
  
        public string Transportation_name { get; set; }
        public string Guide_name { get; set; }
        public string Guide_mobile { get; set; }
        public string Hotel_name { get; set; }
        public int No_of_days { get; set; }

        public string Hotel_Address { get; set; }
        public int Price { get; set; }
        public int cityid { get; set; }
        public int Transportation_id { get; set; }
        public int Guide_id { get; set; }
        public int hotel_id { get; set; }

        public static  List<Package_Information> data = new List<Package_Information>();
    }
}