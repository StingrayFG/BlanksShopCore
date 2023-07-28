using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    public class Part: Product
    {
        public decimal ManufacturingCost { get; private set; }

        public Part(int id, string name, Vector3 dimensions, Material material, double weight, decimal manufacturingCost) : base(id, name, dimensions, material, weight)
        {
            ManufacturingCost = manufacturingCost;
        }

        public Part(string name, Vector3 dimensions, Material material, double weight, decimal manufacturingCost) : base(name, dimensions, material, weight)
        {
            ManufacturingCost = manufacturingCost;
        }
    }
}
