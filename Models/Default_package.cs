using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tourism_1.Models
{
    public class Default_package
    {
        public int Id { get; set; }
        
        public string Package_name { get; set; }
        public int Price { get; set; }
        public int CityId { get; set; }
        public List<Default_package> Add()
        {
            List<Default_package> packages = new List<Default_package>();
            packages.Add(new Default_package() { Id = 1, Package_name = "Luxury", Price = 15000,CityId=1 });
            return packages;
                
        }
    }
    

}