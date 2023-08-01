using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ShoppingCart: EntityBase
    {
        public decimal? Price { get; set; }
        public int CustomerID { get; set; }
        public int? OrderID { get; set; }

        public List<Product>? Products { get; set; }

        public ShoppingCart(int id, int customerID)
        {
            ID = id;
            CustomerID = customerID;
        }

        public ShoppingCart(int customerID)
        {
            ID = 0;
            CustomerID = customerID;
        }

        public void RecalcPrice()
        {
            Price = 0;
            if (Products != null)
            {
                foreach (Product p in Products)
                {
                    Price += p.Price;
                }
            }
        }

        public void AddProduct(Product p)
        {
            Products.Add(p);
        }

        public void RemoveProduct(Product p) 
        {
            Products.Remove(p);
        }
    }
}
