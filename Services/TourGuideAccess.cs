using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tourism_1.Models;

namespace Tourism_1.Services
{
    public class TourGuideAccess
    {

        TourismEntities5 context;
        public TourGuideAccess()
        {
            context = new TourismEntities5();

        }



        public Models.TourGuide Create(Models.TourGuide entity)
        {
            var result = context.TourGuides.Add(entity);
            context.SaveChanges();
            return result;
        }

        public bool Delete(int id)
        {
            var recordToDelete = context.TourGuides.Find(id);
            if (recordToDelete == null)
            {
                throw new Exception("Record for Delete is not found");

            }
            context.TourGuides.Remove(recordToDelete);
            int result = context.SaveChanges();

            if (result > 0) return true;
            else
            {
                return false;
            }
        }
        public IEnumerable<TourGuide> GetAllTourGuides()
        {
            return context.TourGuides.ToList();

        }
        public TourGuide GetTourGuideById(int id)
        {
            var record = context.TourGuides.Find(id);

            if (record == null)
                throw new Exception("Record  not found");
            return record;
        }
        public void UpdateTourGuide(int id, TourGuide entity)
        {
            try
            {
                var recordToUpate = context.TourGuides.Find(id);


                recordToUpate.GuideName = entity.GuideName;
                recordToUpate.GuideMobile = entity.GuideMobile;
                recordToUpate.GuideAddress = entity.GuideAddress;
                recordToUpate.Charges = entity.Charges;
                recordToUpate.GuideEmail = entity.GuideEmail;
                recordToUpate.CityId = entity.CityId;

                context.SaveChanges();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}