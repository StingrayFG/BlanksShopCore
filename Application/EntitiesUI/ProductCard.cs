using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.EntitiesUI
{
    public class ProductCard
    {
        public int ID { get; private set; }
        public ProductType ProductType { get; private set; }
        public Material Material { get; private set; }
        public List<Product> Products { get; private set; } = new List<Product>();

        public ProductCard(Material material, ProductType productType)
        {
            Material = material;
            ProductType = productType;
        }

        public ProductCard(int id, Material material, ProductType productType)
        {
            ID = id;
            Material = material;
            ProductType = productType;
        }

        public void AddProduct(Product product)
        {
            Products.Add(product);
        }

        public void SortProducts()
        {
            Products = Products.OrderBy(p => p.Dimensions.Length).ToList();
        }
    }
}
