using System;
using System.Numerics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Infrastructure.EntitiesEF
{
    public class MetalBlankEF: EntityBase
    {
        public string Name { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        public double Length { get; set; }
        public int MaterialID { get; set; }

        public double? Weight { get; set; }
        public decimal? Price { get; set; }
        public int? Count { get; set; }

        public MetalBlankEF()
        {

        }

        public MetalBlankEF(MetalBlank metalBlank)
        {
            ID = metalBlank.ID;
            Name = metalBlank.Name;
            Width = metalBlank.Dimensions.Width;
            Height = metalBlank.Dimensions.Height;
            Length = metalBlank.Dimensions.Length;
            MaterialID = metalBlank.Material.ID;
            Weight = metalBlank.Weight;
            Price = metalBlank.Price;
            Count = metalBlank.Count;
        }

        public MetalBlank Convert()
        {
            MetalBlank metalBlank = new MetalBlank
            {
                ID = this.ID,
                Name = this.Name,
                Dimensions = new Dimensions(Width, Height, Length),
                Weight = this.Weight,
                Price = this.Price,
                Count = this.Count,
            };

            return metalBlank;
        }

    }
}
