using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public abstract class Product: EntityBase
    {
        public string Name { get; set; }
        public Dimensions Dimensions { get; set; }
        public Material Material { get; set; }

        public double? Weight { get; set; }
        public decimal? Price { get; set; }
        public int? Count { get; set; }

        public Product()
        {

        }

        public Product(int id, string name, Dimensions dimensions, Material material)
        {
            ID = id;
            Name = name;
            Dimensions = dimensions;
            Material = material;
        }

        public Product(string name, Dimensions dimensions, Material material)
        {
            ID = 0;
            Name = name;
            Dimensions = dimensions;
            Material = material;
        }

        public void UpdateName(string name)
        {
            Name = name;
        }

        public void UpdateCount(int count)
        {
            Count = count;
        }

    }
}
