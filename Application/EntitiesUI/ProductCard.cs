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
        public string Name { get; private set; }
        public Material Material { get; private set; }
        public List<Product> Products { get; private set; } = new List<Product>();

        public ProductCard(string name, Material material)
        {
            Name = name;
            Material = material;
        }

        public ProductCard(int id, string name, Material material)
        {
            ID = id;
            Name = name;
            Material = material;
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
