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
        protected IShoppingCartRepository<ShoppingCart> _repository;
        protected IRepository<MetalBlank> _blanksRepository;

        public ShoppingCartAppService()
        {
            _repository = new ShoppingCartRepository();
            _blanksRepository = new Repository<MetalBlank>();
        }

        public ShoppingCartAppService(ShoppingCartRepository repository, IRepository<MetalBlank> blanksRepository)
        {
            _repository = repository;
            _blanksRepository = blanksRepository;
        }

        public void AddProduct(int customerID, int productID)
        {
            _repository.Add(customerID, productID);
        }

        public void DeleteProductByID(int customerID, int productID)
        {
            ShoppingCart? shoppingCart = _repository.GetCurrentByCustomer(customerID);
            if (shoppingCart  != null) 
            {
                _repository.DeleteProductByID(shoppingCart.ID, productID);
            }
            
        }

        public ShoppingCart? GetByID(int id)
        {
            return _repository.GetByID(id);
        }

        public ShoppingCart? GetCurrentByCustomer(int customerID)
        {
            return _repository.GetCurrentByCustomer(customerID);
        }

        public List<ShoppingCart>? GetByCustomer(int customerID)
        {
            return _repository.GetByCustomer(customerID);
        }

        public List<ShoppingCart>? GetAll()
        {
            return _repository.GetAll();
        }

        public void DeleteByID(int id)
        {
            _repository.DeleteByID(id);
        }
    }
}
