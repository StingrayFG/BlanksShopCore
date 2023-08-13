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
        public string Name { get; protected set; }
        public Dimensions Dimensions { get; protected set; }
        public Material Material { get; protected set; }

        public double? Weight { get; protected set; }
        public decimal? Price { get; protected set; }
        public int? Count { get; protected set; }

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
