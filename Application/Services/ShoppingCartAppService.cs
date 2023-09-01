using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain.Entities;
using Infrastructure.EntitiesEF;
using Infrastructure.Interfaces;
using Infrastructure.Repositories;

namespace Application.Services
{
    public class ShoppingCartAppService : IShoppingCartAppService<ShoppingCart>
    {
        protected IShoppingCartRepository<ShoppingCart> _shoppingCartRepository;
        protected IMetalBlankRepository<MetalBlank> _metalBlankRepository;

        public ShoppingCartAppService()
        {
            _shoppingCartRepository = new ShoppingCartRepository();
            _metalBlankRepository = new MetalBlankRepository();
        }

        public ShoppingCartAppService(IShoppingCartRepository<ShoppingCart> shoppingCartRepository, IMetalBlankRepository<MetalBlank> metalBlankRepository)
        {
            _shoppingCartRepository = shoppingCartRepository;
            _metalBlankRepository = metalBlankRepository;
        }

        public void AddProduct(int customerID, int productID)
        {
            ShoppingCart? shoppingCart = _shoppingCartRepository.GetCurrentByCustomer(customerID);
            MetalBlank? metalBlank = _metalBlankRepository.GetByID(productID);
            if (metalBlank != null)
            {
                if (shoppingCart == default(ShoppingCart))
                {
                    shoppingCart = new ShoppingCart(_shoppingCartRepository.GetLastID() + 1, customerID);
                }

                metalBlank.UpdateCount(1);
                shoppingCart.AddProduct(metalBlank);
                _shoppingCartRepository.Update(shoppingCart);
 
            }
        }

        public void UpdateProductCount(int customerID, int productID, int count)
        {
            ShoppingCart? shoppingCart = _shoppingCartRepository.GetCurrentByCustomer(customerID);
            if (shoppingCart != null) 
            {
                Product product = (from p in shoppingCart.Products where (p.ID == productID) select p).FirstOrDefault();
                {
                    if (product == default) 
                    {
                        AddProduct(customerID, productID);
                    }
                    else if (product != null) 
                    {
                        product.UpdateCount(count);     
                    }
                    _shoppingCartRepository.Update(shoppingCart);
                }
            }
            
        }

        public void DeleteProduct(int customerID, int productID)
        {
            ShoppingCart? shoppingCart = _shoppingCartRepository.GetCurrentByCustomer(customerID);
            if (shoppingCart != null) 
            {
                _shoppingCartRepository.DeleteProduct(shoppingCart.ID, productID);
            }
            
        }

        public ShoppingCart? GetByID(int id)
        {
            return _shoppingCartRepository.GetByID(id);
        }

        public ShoppingCart? GetCurrentByCustomer(int customerID)
        {
            return _shoppingCartRepository.GetCurrentByCustomer(customerID);
        }

        public List<ShoppingCart>? GetByCustomer(int customerID)
        {
            return _shoppingCartRepository.GetByCustomer(customerID);
        }

        public List<ShoppingCart>? GetAll()
        {
            return _shoppingCartRepository.GetAll();
        }

        public void DeleteByID(int id)
        {
            _shoppingCartRepository.DeleteByID(id);
        }
    }
}
