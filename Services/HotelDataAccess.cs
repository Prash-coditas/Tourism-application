using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tourism_1.Models;

namespace Tourism_1.Services
{
    public class HotelDataAccess
    {

        TourismEntities5 context;
        public HotelDataAccess()
        {
            context = new TourismEntities5();

        }



        public Models.Hotel Create(Models.Hotel entity)
        {
            var result = context.Hotels.Add(entity);
            context.SaveChanges();
            return result;
        }

        public void Delete(int id)
        {
            var recordToDelete = context.Hotels.Find(id);
            if (recordToDelete == null)
            {
                throw new Exception("Record for Delete is not found");

            }
            context.Hotels.Remove(recordToDelete);
            context.SaveChanges();

            
        }
        public IEnumerable<Models.Hotel> GetAllHotels()
        {
            return context.Hotels.ToList();

        }
        public Hotel GetHotelById(int id)
        {
            var record = context.Hotels.Find(id);

            if (record == null)
                throw new Exception("Record  not found");
            return record;
        }
        public void UpdateHotel(int hotelid, Hotel entity)
        {
            try
            {
                var recordToUpate = context.Hotels.Find(hotelid);


                recordToUpate.HotelName = entity.HotelName;
                recordToUpate.HotelType = entity.HotelType;
                recordToUpate.HotelDesc = entity.HotelDesc;
                recordToUpate.HotelAddress = entity.HotelAddress;
                recordToUpate.Hotelrentperday = entity.Hotelrentperday;


                context.SaveChanges();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}