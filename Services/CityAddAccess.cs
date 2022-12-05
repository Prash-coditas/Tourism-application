using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tourism_1.Models;
namespace Tourism_1.Services
{
    public class CityAddAccess
    {

        TourismEntities5 context;
        public CityAddAccess()
        {
            this.context = new TourismEntities5();

        }

        public void Create(City entity)
        {
            var result = context.Cities.Add(entity);
            context.SaveChanges();

        }

        public bool Delete(int id)
        {
            var recordToDelete = context.Cities.Find(id);
           
            
            if (recordToDelete == null)
            {
                throw new Exception("Record for Delete is not found");

            }
            context.Cities.Remove(recordToDelete);
            int result = context.SaveChanges();

            if (result > 0) return true;
            else
            {
                return false;
            }
        }
        public IEnumerable<City> GetAllCities()
        {
            return context.Cities.ToList();

        }
        public City GetCityById(int id)
        {
            var record = context.Cities.Find(id);

            if (record == null)
                throw new Exception("Record  not found");
            return record;
        }
        public void UpdateCity(int id, City entity)
        {
            try
            {
                var recordToUpate = context.Cities.Find(id);


                recordToUpate.CityName = entity.CityName;


                context.SaveChanges();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}