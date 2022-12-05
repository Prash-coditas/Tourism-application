using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tourism_1.Models;

namespace Tourism_1.Services
{
    public class RolesdataAccess
    {
        TourismEntities5 context;
        public RolesdataAccess()
        {
            context = new TourismEntities5();
        }

        public IEnumerable<Models.Role> Allroles()
        {
            var result=context.Roles.ToList();
            return result;
        }
    
    }
}