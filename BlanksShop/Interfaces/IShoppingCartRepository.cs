using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IShoppingCartRepository<T>
    {
        public void Update(T entity);
        public void DeleteProduct(int shoppingCartID, int productID);

        public void UpdateOrder(int shoppingCartID, int orderID);
        public int GetLastID();
        public T? GetByID(int id);
        public T? GetByOrder(int orderID);
        public T? GetCurrentByCustomer(int customerID);
        public List<T>? GetByCustomer(int customerID);
        public List<T>? GetAll();
        public void DeleteByID(int id);

    }
}
