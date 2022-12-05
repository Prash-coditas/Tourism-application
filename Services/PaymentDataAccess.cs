using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tourism_1.Models;

namespace Tourism_1.Services
{
    public class PaymentDataAccess
    {
        TourismEntities5 context;
        public PaymentDataAccess()
        {
            this.context = new TourismEntities5();

        }

        public void Create(Payment payment)
        {
            var result = context.Payments.Add(payment);
            context.SaveChanges();

        }
    }
}