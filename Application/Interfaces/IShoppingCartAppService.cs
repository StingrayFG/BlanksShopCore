using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface IShoppingCartAppService<T>
    {
        public void AddProduct(int customerID, int productID);
        public void DeleteProductByID(int customerID, int productID);
        public T? GetByID(int id);
        public T? GetByCustomer(int customerID);
        public List<T>? GetAll();
        public void DeleteByID(int id);

    }
}
