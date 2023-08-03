using System;
using System.Numerics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Infrastructure.EntitiesEF
{
    public class ShoppingCartEF: ShoppingCart
    {
        public int CustomerID { get; set; }
        public int? OrderID { get; set; }
        public int ProductID { get; set; }
        public int Count { get; set; }
        public decimal? Price { get; set; }

        public ShoppingCartEF()
        {

        }

        public ShoppingCartEF(ShoppingCart shoppingCart, Product product)
        {
            
        }

        public ShoppingCart Convert()
        {
            return new ShoppingCart()
            {
                CustomerID = CustomerID,
                OrderID = OrderID
            };
        }
    }
}
