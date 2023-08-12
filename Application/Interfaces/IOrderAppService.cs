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
    public interface IOrderAppService<T>
    {
        public void Add(int customerID, string paymentMethod);
        public T? GetByID(int id);
        public List<T>? GetAll();
        public void UpdatePayment(int id, string payment);
        public void DeleteByID(int id);

    }
}
