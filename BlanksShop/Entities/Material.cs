using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Material: EntityBase
    {
        public string Name { get; set; }
        public double Density { get; set; }
        public decimal? PricePerKilogram { get; set; }

        public Material(int id, string name, double density, decimal pricePerKilogram)
        {
            ID = id;
            Name = name;
            Density = density;
            PricePerKilogram = pricePerKilogram;
        }

        public Material(string name, double density, decimal pricePerKilogram)
        {
            ID = 0;
            Name = name;
            Density = density;
            PricePerKilogram = pricePerKilogram;
        }
        public void UpdateName(string name)
        {
            Name = name;
        }

    }
}
