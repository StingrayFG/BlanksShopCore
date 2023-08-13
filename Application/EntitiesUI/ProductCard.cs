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
        public string Name { get; private set; }
        public string MaterialName { get; private set; }
        public List<Product> Products { get; private set; } = new List<Product>();

        public ProductCard(string name, string materialName)
        {
            Name = name;
            MaterialName = materialName;
        }

        public void AddProduct(Product product) 
        {
            Products.Add(product);  
        }
    }
}
