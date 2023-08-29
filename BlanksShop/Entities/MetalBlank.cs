using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class MetalBlank: Product
    {
        public MetalBlank(): base() { }

        public MetalBlank(int id, string name, Dimensions dimensions, Material material) : base(id, name, dimensions, material)
        {

        }

        public MetalBlank(string name, Dimensions dimensions, Material material): base (name, dimensions, material)
        {

        }

    }
}
