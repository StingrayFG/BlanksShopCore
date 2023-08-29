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
        public DateTime CreationDate { get; private set; }
        public decimal? Price { get; private set; }
        public string? PaymentMethod { get; private set; }
        public int CustomerID { get; private set; }
        public ShoppingCart ShoppingCart { get; private set; }

        public Order()
        {

        }

        public Order(int id, int customerID, ShoppingCart shoppingCart, string paymentMethod)
        {
            ID = id;
            CustomerID = customerID;
            ShoppingCart = shoppingCart;
            PaymentMethod = paymentMethod;
            CreationDate = DateTime.Now;

            CalcPrice();
        }

        public Order(int customerID, ShoppingCart shoppingCart, string paymentMethod)
        {
            ID = 0;
            CustomerID = customerID;
            ShoppingCart = shoppingCart;
            PaymentMethod = paymentMethod;
            CreationDate = DateTime.Now;

            CalcPrice();
        }

        public void SetProperties(int id, DateTime creationDate, decimal? price, string? paymentMethod, int customerID)
        { 
            ID = id;
            CreationDate = creationDate;
            Price = price;
            PaymentMethod = paymentMethod;
            CustomerID = customerID;
        }

        public void SetShoppingCart(ShoppingCart shoppingCart)
        {
            ShoppingCart = shoppingCart;
        }

        public void CalcPrice()
        {
            Price = ShoppingCart.Price;
        }

        public void UpdatePayment(string payment)
        {
            PaymentMethod = payment;
        }

    }
}
