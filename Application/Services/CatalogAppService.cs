using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.EntitiesUI;
using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Interfaces;
using Infrastructure.Repositories;

namespace Application.Services
{
    public class CatalogAppService: ICatalogAppService<ProductCard>
    {
        protected IMetalBlankRepository<MetalBlank> _repository;
        protected IRepository<Material> _materialsRepository;

        public CatalogAppService()
        {
            _repository = new MetalBlankRepository();
            _materialsRepository = new Repository<Material>();
        }

        public virtual List<ProductCard>? GetAll()
        {
            List<MetalBlank>? metalBlanks = _repository.GetAll();
            List<ProductCard>? res = new List<ProductCard>();

            if (metalBlanks != null)
            {
                int lastUsedID = 0;
                foreach (MetalBlank metalBlank in metalBlanks)
                {
                    ProductCard? productCard = res.Where(e => e.Material.ID == metalBlank.Material.ID && e.ProductType.ID == metalBlank.ProductType.ID).FirstOrDefault();
                    if (productCard != default(ProductCard))
                    {
                        productCard.AddProduct(metalBlank);
                    }
                    else
                    {
                        lastUsedID++;
                        ProductCard newProductCard = new ProductCard(lastUsedID, metalBlank.Material, metalBlank.ProductType);
                        newProductCard.AddProduct(metalBlank);
                        res.Add(newProductCard);
                    }
                }

                foreach (ProductCard productCard in res) 
                {
                    productCard.SortProducts();
                }
            }
            return res;

        }
    }
}
