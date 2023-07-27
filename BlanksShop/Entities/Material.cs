using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    public class Material
    {
        public int ID { get; private set; }

        public string Name { get; private set; }
        public double Density { get; private set; }
        public decimal? PricePerKilogram { get; private set; }

        public Material(int id, string name, double density, decimal pricePerKilogram) 
        { 
            ID = id;
            Name = name;
            Density = density; 
            PricePerKilogram = pricePerKilogram;
        }

        public Material(string name, double density, decimal pricePerKilogram)
        {
            ID = 1;
            Name = name;
            Density = density;
            PricePerKilogram = pricePerKilogram;
        }
    }
}
