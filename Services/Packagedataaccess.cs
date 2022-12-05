using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tourism_1.Models;

namespace Tourism_1.Services
{
    public class Packagedataaccess
    {
        TourismEntities5 context;
        public Packagedataaccess()
        {
            context = new TourismEntities5();

        }



        public void  Create(package entity)
        {
            var result = context.packages.Add(entity);
             context.SaveChanges();
        //    return result;
        
        }

        public bool Delete(int id)
        {
            var recordToDelete = context.packages.Find(id);
            if (recordToDelete == null)
            {
                throw new Exception("Record for Delete is not found");

            }
            context.packages.Remove(recordToDelete);
            int result = context.SaveChanges();

            if (result > 0) return true;
            else
            {
                return false;
            }
        }
        public IEnumerable<package> GetAllPackage()
        {
            return context.packages.ToList();

        }
        public Models.package GetPackageById(int id)
        {
            var record = context.packages.Find(id);

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

        //}
    }
}