using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Interfaces;
using Infrastructure.Repositories;

namespace Application.Services
{
    public class ShoppingCartAppService : IShoppingCartAppService<ShoppingCart>
    {
        protected IShoppingCartRepository<ShoppingCart> _shoppingCartRepository;
        protected IRepository<MetalBlank> _blanksRepository;

        public ShoppingCartAppService()
        {
            _shoppingCartRepository = new ShoppingCartRepository();
            _blanksRepository = new Repository<MetalBlank>();
        }

        public ShoppingCartAppService(ShoppingCartRepository repository, IRepository<MetalBlank> blanksRepository)
        {
            _shoppingCartRepository = repository;
            _blanksRepository = blanksRepository;
        }

        public void AddProduct(int customerID, int productID)
        {
            int? shoppingCartID = _shoppingCartRepository.GetCurrentByCustomer(customerID).ID;
            if (shoppingCartID == null)
            {
                shoppingCartID = _shoppingCartRepository.GetLastID();
            }

            _shoppingCartRepository.Add((int)shoppingCartID, customerID, productID);
        }

        public void DeleteProductByID(int customerID, int productID)
        {
            ShoppingCart? shoppingCart = _shoppingCartRepository.GetCurrentByCustomer(customerID);
            if (shoppingCart != null) 
            {
                _shoppingCartRepository.DeleteProductByID(shoppingCart.ID, productID);
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
