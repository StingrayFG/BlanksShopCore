using Domain.Entities;
using Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.EntitiesEF;
using System.Security;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class ShoppingCartRepository: IShoppingCartRepository<ShoppingCart> 
    {

        private IRepository<ShoppingCartEF> _shoppingCartRepository;
        private IMetalBlankRepository<MetalBlank> _metalBlankRepository;

        public ShoppingCartRepository()
        {
            _shoppingCartRepository = new Repository<ShoppingCartEF>();
            _metalBlankRepository = new MetalBlankRepository();
        }

        public ShoppingCartRepository(IRepository<ShoppingCartEF> shoppingCartRepository, IMetalBlankRepository<MetalBlank> metalBlankRepository)
        {
            _shoppingCartRepository = shoppingCartRepository;
            _metalBlankRepository = metalBlankRepository;
        }

        public void Add(int shoppingCartID, int customerID, int productID)
        {
            MetalBlank? metalBlank = _metalBlankRepository.GetByID(productID);
            if (metalBlank != null)
            {
                _shoppingCartRepository.Add(new ShoppingCartEF()
                {
                    ID = shoppingCartID,
                    CustomerID = customerID,
                    OrderID = null,
                    ProductID = productID,
                    Count = 1,
                    Price = metalBlank.Price
                });
            }
        }

        public void DeleteProductByID(int shoppingCartID, int productID)
        {
            List<ShoppingCartEF>? shoppingCartsEF = _shoppingCartRepository.GetAll();
            if (shoppingCartsEF != null)
            {
                foreach (ShoppingCartEF shoppingCartEF in shoppingCartsEF)
                {
                    if ((shoppingCartEF.ID == shoppingCartID) && (shoppingCartEF.ProductID == productID))
                    {
                        _shoppingCartRepository.Delete(shoppingCartEF);
                    }
                }
            }
        }


        public void UpdateOrder(int shoppingCartID, int orderID)
        {
            List<ShoppingCartEF>? shoppingCartsEF = (from r in _shoppingCartRepository.GetAll() where (r.ID == shoppingCartID) select r).ToList();
            if (shoppingCartsEF != null) 
            {
                foreach (ShoppingCartEF shoppingCartEF in shoppingCartsEF)
                {
                    shoppingCartEF.OrderID = orderID;   
                    _shoppingCartRepository.Update(shoppingCartEF);
                }
            }
        }

        public ShoppingCart? GetByID(int id)
        {
            List<ShoppingCart>? shoppingCarts = GetAll();
            ShoppingCart? res = (from r in shoppingCarts where (r.ID == id) select r).First();
            return res;
        }

        public ShoppingCart? GetCurrentByCustomer(int customerID)
        {
            List<ShoppingCart>? shoppingCarts = GetAll();
            ShoppingCart? res = (from r in shoppingCarts where ((r.CustomerID == customerID) && (r.OrderID == null)) select r).Last();
            return res;
        }

        public List<ShoppingCart>? GetByCustomer(int customerID)
        {
            List<ShoppingCart>? shoppingCarts = GetAll();
            List<ShoppingCart>? res = (from r in shoppingCarts where ((r.CustomerID == customerID)) select r).ToList();
            return res;
        }

        public List<ShoppingCart>? GetAll()
        {
            List<ShoppingCartEF>? shoppingCartsEF = _shoppingCartRepository.GetAll();
            List<ShoppingCart> res = new List<ShoppingCart>();

            if (shoppingCartsEF != null)
            {
                int? currentID = shoppingCartsEF.First().ID;
                ShoppingCart currentCart = new ShoppingCart();

                foreach (ShoppingCartEF shoppingCartEF in shoppingCartsEF)
                {           
                    
                    if (shoppingCartEF.ID != currentID)
                    {                    
                        res.Add(currentCart);

                        currentCart = new ShoppingCart();

                        currentID = shoppingCartEF.ID;
                    }
                    
                    if (shoppingCartEF.ID == currentID)
                    {
                        shoppingCartEF.Convert(currentCart);

                        MetalBlank? currentProduct = _metalBlankRepository.GetByID(shoppingCartEF.ProductID);
                        if (currentProduct != null)
                        {
                            currentProduct.UpdateCount(shoppingCartEF.Count);
                            currentCart.AddProduct(currentProduct);
                        }                       
                    }

                    
                }

                res.Add(currentCart);
            }
            return res;
        }

        public void DeleteByID(int id)
        {
            List<ShoppingCartEF>? shoppingCartsEF = _shoppingCartRepository.GetAll();
            if (shoppingCartsEF != null)
            {
                foreach (ShoppingCartEF shoppingCartEF in shoppingCartsEF)
                {
                    if (shoppingCartEF.ID == id)
                    {
                        _shoppingCartRepository.Delete(shoppingCartEF);
                    }
                }
            }
        }

    }
}
