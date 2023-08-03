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

namespace Infrastructure.Repositories
{
    public class ShoppingCartRepository : IShoppingCartRepository<ShoppingCart>
    {
        private IRepository<ShoppingCartEF> _shoppingCartRepository;
        private IRepository<MetalBlankEF> _metalBlankRepository;   


        public ShoppingCartRepository()
        {
            _shoppingCartRepository = new Repository<ShoppingCartEF>();
            _metalBlankRepository = new Repository<MetalBlankEF>();
        }

        public ShoppingCartRepository(IRepository<ShoppingCartEF> shoppingCartRepository, IRepository<MetalBlankEF> metalBlankRepository)
        {
            _shoppingCartRepository = shoppingCartRepository;
            _metalBlankRepository = metalBlankRepository;       
        }
        
        public ShoppingCart GetByID(int id) 
        {
            List<ShoppingCart>? shoppingCarts = GetAll();
            ShoppingCart? res = (from r in shoppingCarts where (r.ID == id) select r).First();
            return res;
        }

        public ShoppingCart GetByCustomer(int id)
        {
            List<ShoppingCart>? shoppingCarts = GetAll();
            ShoppingCart? res = (from r in shoppingCarts where ((r.CustomerID == id) && (r.OrderID == null)) select r).First();
            return res;
        }

        public List<ShoppingCart>? GetAll()
        {
            List<ShoppingCartEF>? shoppingCartsEF = _shoppingCartRepository.GetAll();
            List<ShoppingCart> res = new List<ShoppingCart>();
            if (shoppingCartsEF != null) 
            { 
                int? currentCustomerID = 0;
                int? currentOrderID = 0;

                foreach (ShoppingCartEF shoppingCartEF in shoppingCartsEF)
                {
                    ShoppingCart currentCart = new ShoppingCart();
                    if ((shoppingCartEF.CustomerID == currentCustomerID) && (shoppingCartEF.OrderID == currentOrderID))
                    {
                        MetalBlank? currentProduct = _metalBlankRepository.GetByID(shoppingCartEF.ProductID);
                        if (currentProduct != null) 
                        {
                            currentCart.AddProduct(currentProduct);
                        }                   
                    }
                    else
                    {
                        currentCustomerID = shoppingCartEF.CustomerID;
                        currentOrderID = shoppingCartEF.OrderID;
                        currentCart = shoppingCartEF.Convert();
                        res.Add(currentCart);
                        currentCart = new ShoppingCart();
                    }
                }
            }
            return res;
        }

        public void Add(int customerID, int productID)
        {
            ShoppingCart shoppingCart = GetByCustomer(customerID);
            MetalBlank metalBlank = _metalBlankRepository.GetByID(productID); 
            if (metalBlank != null) 
            {
                _shoppingCartRepository.Add(new ShoppingCartEF()
                {
                    CustomerID = customerID,
                    OrderID = null,
                    ProductID = productID,
                    Count = 1,
                    Price = metalBlank.Price
                });
            }
        }

        public void DeleteByID(int id)
        {
            List<ShoppingCartEF>? shoppingCartsEF = _shoppingCartRepository.GetAll();
            if (shoppingCartsEF != null)
            {
                foreach(ShoppingCartEF shoppingCartEF in shoppingCartsEF)
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
