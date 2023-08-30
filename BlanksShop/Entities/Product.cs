using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Domain.Entities
{
    public abstract class Product: EntityBase
    {
        public Dimensions Dimensions { get; protected set; }
        public Material Material { get; protected set; }
        public ProductType ProductType { get; protected set; }

        public double? Weight { get; protected set; }
        public decimal? Price { get; protected set; }
        public int Count { get; protected set; }

        public Product()
        {

        }

        public Product(int id, Dimensions dimensions, Material material, ProductType productType)
        {
            ID = id;
            Dimensions = dimensions;
            Material = material;
            ProductType = productType;
        }

        public Product(Dimensions dimensions, Material material, ProductType productType)
        {
            ID = 0;
            Dimensions = dimensions;
            Material = material;
            ProductType = productType;
        }

        public void SetProperties(int id, Dimensions dimensions, double? weight, decimal? price, int count)
        {
            ID = id;
            Dimensions = dimensions;
            Weight = weight;
            Price = price;
            Count = count;
        }
        public void UpdateMaterial(Material material)
        {
            Material = material;
            
        }

        public void UpdateProductType(ProductType productType)
        {
            ProductType = productType;
        }


        public void UpdateCount(int count)
        {
            Count = count;
        }

    }
}
