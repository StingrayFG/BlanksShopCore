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
        public DateTime OrderCreationDate { get; set; }
        public decimal? Price { get; set; }
        public string? PaymentMethod { get; set; }
        public int CustomerID { get; set; }

        public OrderEF()
        {

        }

        public OrderEF(Order order)
        {
            ID = order.ID;
            OrderCreationDate = order.OrderCreationDate;
            Price = order.Price;
            PaymentMethod = order.PaymentMethod;
            CustomerID = order.CustomerID;
        }

        public void Convert(Order order)
        {
            order.ID = ID;
            order.OrderCreationDate = OrderCreationDate;
            order.Price = Price;
            order.PaymentMethod = PaymentMethod;
            order.CustomerID = CustomerID;
        }

    }
}
