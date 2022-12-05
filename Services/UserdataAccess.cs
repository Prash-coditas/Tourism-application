using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Tourism_1.Models;


namespace Tourism_1.Services
{
    public class UserdataAccess 
    {
        TourismEntities5 context;
        public UserdataAccess()
        {
            context = new TourismEntities5();

        }


        
        public User Create(Models.User entity)
        {
            var result = context.Users.Add(entity);
            context.SaveChanges();
            return result;
        }

        public bool Delete(int id)
        {
            var recordToDelete = context.Users.Find(id);
            if(recordToDelete==null)
            {
                throw new Exception("Record for Delete is not found");

            }
            context.Users.Remove(recordToDelete);
            int result = context.SaveChanges();
            
            if (result > 0) return true;
            else
            {
                return false;
            }
        }
        public IEnumerable<User> GetAllUser()
        {
            return context.Users.ToList();

        }
        public Models.User GetUserById(int id)
        {
            var record = context.Users.Find(id);
          
            if (record == null)
                throw new Exception("Record  not found");
            return record;
        }
        public Models.User UpdateUser(int id,Models.User entity)
        {
            try
            {
                var recordToUpate = context.Users.Find(id);
                if (recordToUpate == null) throw new Exception("Record for Deleteupdate is not found");

                recordToUpate.BirthDate = entity.BirthDate;
                recordToUpate.UserEmail = entity.UserEmail;
                recordToUpate.UserAddress = entity.UserAddress;
                recordToUpate.UserName = entity.UserName;

                context.SaveChanges();
                return recordToUpate;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

    }
}