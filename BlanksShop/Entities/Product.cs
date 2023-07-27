using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    public class Product
    {
        public int ID { get; private set; }

        public string Name { get; private set; }
        public Vector3 Dimensions { get; private set; }
        public Material Material { get; private set; }

        public double? Weight { get; private set; }
        public decimal? Price { get; private set; }
        public int? Count { get; private set; }

        public Product(int id, string name, Vector3 dimensions, Material material, double weight)
        {
            ID = id;
            Name = name;
            Dimensions = dimensions;
            Material = material;
            Weight = weight;
            Price = (decimal)weight * material.PricePerKilogram;
        }

        public Product(string name, Vector3 dimensions, Material material, double weight)
        {
            ID = 1;
            Name = name;
            Dimensions = dimensions;
            Material = material;
            Weight = weight;
            Price = (decimal)weight * material.PricePerKilogram;
        }

    }
}
