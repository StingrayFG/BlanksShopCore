using System;
using System.Numerics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Infrastructure.EntitiesEF
{
    public class ShoppingCartEF: EntityBase
    {
        public int ID { get; set; }
        public int CustomerID { get; set; }
        public int? OrderID { get; set; }
        public int ProductID { get; set; }
        public int Count { get; set; }
        public decimal? Price { get; set; }

        public ShoppingCartEF()
        {

        }

        public void Convert(ShoppingCart shoppingCart)
        {
            shoppingCart.SetProperties(ID, Price, CustomerID, OrderID);
        }
    }
}
