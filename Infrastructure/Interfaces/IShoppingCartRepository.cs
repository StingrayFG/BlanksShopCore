using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Infrastructure.Interfaces
{
    public interface IShoppingCartRepository<T>
    {
        public void Add(int customerID, int productID);
        public void DeleteProductByID(int shoppingCartID, int productID);

        public T? GetByID(int id);
        public T? GetCurrentByCustomer(int customerID);
        public List<T>? GetByCustomer(int customerID);
        public List<T>? GetAll();
        public void DeleteByID(int id);

    }
}
