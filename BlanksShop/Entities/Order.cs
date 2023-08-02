using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Domain.Entities
{
    public class Order: EntityBase
    {
        public DateTime OrderCreationDate { get; set; }
        public decimal? Price { get; set; }
        public string? PaymentMethod { get; set; }
        public int CustomerID { get; set; }
        public ShoppingCart ShoppingCart { get; set; }

        public Order(int id, int customerID, ShoppingCart shoppingCart)
        {
            ID = id;
            CustomerID = customerID;
            ShoppingCart = shoppingCart;

            CalcPrice();
        }

        public Order(int customerID, ShoppingCart shoppingCart)
        {
            ID = 0;
            CustomerID = customerID;
            ShoppingCart = shoppingCart;

            CalcPrice();
        }
        public void CalcPrice()
        {
            Price = ShoppingCart.Price;
        }

    }
}
