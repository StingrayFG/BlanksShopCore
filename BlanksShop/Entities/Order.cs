using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Order: EntityBase
    {
        public DateTime OrderCreationDate { get; set; }
        public decimal Price { get; set; }
        public string PaymentMethod { get; set; }

        public int CustomerID { get; set; }
    }
}
