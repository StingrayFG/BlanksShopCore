using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ShoppingCart : EntityBase
    {
        public decimal? Price { get; private set; }
        public int CustomerID { get; private set; }
        public int? OrderID { get; private set; }

        public List<Product>? Products { get; set; } = new List<Product>();

        public ShoppingCart()
        {

        }

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

        public void SetProperties(int id, decimal? price,  int customerID, int? orderID)
        {
            ID = id;
            Price = price;
            CustomerID = customerID;
            OrderID = orderID;
        }

        public void RecalcPrice()
        {
            Price = 0;
            if (Products != null)
            {
                foreach (Product p in Products)
                {
                    Price += p.Price * p.Count;
                }
            }
        }

        public void UpdateOrder(int orderID)
        {
            OrderID = orderID;
        }

        public void AddProduct(Product product)
        {
            bool isFound = false;
            foreach (Product p in Products)
            {
                if (p.ID == product.ID)
                {
                    p.UpdateCount(p.Count + product.Count);
                    isFound = true;
                }
            }

            if (!isFound)
            {
                Products.Add(product);
            }

            RecalcPrice();
        }

        public void RemoveProduct(Product product) 
        {
            Products.Remove(product);
            RecalcPrice();
        }
    }
}
