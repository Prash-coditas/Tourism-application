using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tourism_1.Models;

namespace Tourism_1.Services
{
    public class PlaceDataAccess
    {

        TourismEntities5 context;
        public PlaceDataAccess()
        {
            context = new TourismEntities5();

        }



        public Models.places_in_city Create(Models.places_in_city entity)
        {
            var result = context.places_in_city.Add(entity);
            context.SaveChanges();
            return result;
        }

        public bool Delete(int id)
        {
            var recordToDelete = context.places_in_city.Find(id);
            if (recordToDelete == null)
            {
                throw new Exception("Record for Delete is not found");

            }
            context.places_in_city.Remove(recordToDelete);
            int result = context.SaveChanges();

            if (result > 0) return true;
            else
            {
                return false;
            }
        }
        public IEnumerable<Models.places_in_city> GetAllPlaces()
        {
            return context.places_in_city.ToList();

        }
        public Models.places_in_city GetPlaceeById(int id)
        {
            var record = context.places_in_city.Find(id);

            if (record == null)
                throw new Exception("Record  not found");
            return record;
        }
        //public Models.package UpdatePackage(int id, Models.package entity)
        //{
        //    try
        //    {
        //        var recordToUpate = context.packages.Find(id);
        //        if (recordToUpate == null) throw new Exception("Record for Deleteupdate is not found");

        //        recordToUpate.BirthDate = entity.BirthDate;
        //        recordToUpate.UserEmail = entity.UserEmail;
        //        recordToUpate.UserAddress = entity.UserAddress;
        //        recordToUpate.UserName = entity.UserName;

        //        context.SaveChanges();
        //        return recordToUpate;
        //    }
        //    catch (Exception ex)
        //    {

        //        throw ex;
        //    }

    }
}