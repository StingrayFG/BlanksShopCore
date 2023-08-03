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

        }

        public ShoppingCart? GetByID(int id)
        {
            return null;
        }

        public ShoppingCart? GetByCustomer(int customerID)
        {
            return null;
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
