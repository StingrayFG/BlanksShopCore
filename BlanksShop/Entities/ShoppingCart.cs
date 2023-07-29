using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    public class ShoppingCart: EntityBase
    {
        public int Count { get; set; }
        public decimal Price { get; set; }
        public int CustomerID { get; set; }
        public int? OrderID { get; set; }

        public List<Product> Products { get; set; }
    }
}
