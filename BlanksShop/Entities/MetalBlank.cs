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

        public MetalBlank(int id, Dimensions dimensions, Material material, ProductType productType) : base(id, dimensions, material, productType)
        {

        }

        public MetalBlank(Dimensions dimensions, Material material, ProductType productType) : base (dimensions, material, productType)
        {

        }

    }
}
