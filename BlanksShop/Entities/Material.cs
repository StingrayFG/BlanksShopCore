using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Material
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public double Density { get; set; }
        public decimal? PricePerKilogram { get; set; }

    }
}
