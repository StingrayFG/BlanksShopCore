using System;
using System;
using System.Numerics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Infrastructure.EntitiesEF
{
    public class OrderEF: EntityBase
    {
        public DateTime CreationDate { get; set; }
        public decimal? Price { get; set; }
        public string? PaymentMethod { get; set; }
        public int CustomerID { get; set; }

        public OrderEF()
        {

        }

        public OrderEF(Order order)
        {
            ID = order.ID;
            CreationDate = order.CreationDate;
            Price = order.Price;
            PaymentMethod = order.PaymentMethod;
            CustomerID = order.CustomerID;
        }

        public void Convert(Order order)
        {
            order.SetProperties(ID, CreationDate, Price, PaymentMethod, CustomerID);
        }

    }
}
