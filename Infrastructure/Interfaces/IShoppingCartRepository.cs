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
    public interface IShoppingCartRepository<T> where T : ShoppingCart
    {
        public T? GetByID(int id);

        public T? GetByCustomer(int id);
        public List<T>? GetAll();
        public void Add(int customerID, int productID);
        public void DeleteByID(int id);

    }
}
