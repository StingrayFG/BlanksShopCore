using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    public class MetalBlank: Product
    {
        public MetalBlank(int id, string name, Vector3 dimensions, Material material, double weight) : base(id, name, dimensions, material, weight)
        {
            
        }

        public MetalBlank(string name, Vector3 dimensions, Material material, double weight) : base(name, dimensions, material, weight)
        {

        }
    }
}
