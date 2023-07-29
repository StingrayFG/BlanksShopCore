using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    public abstract class Product: EntityBase
    {
        public string Name { get; set; }
        public Vector3 Dimensions { get; set; }
        public Material Material { get; set; }

        public double? Weight { get; set; }
        public decimal? Price { get; set; }
        public int? Count { get; set; }

    }
}
