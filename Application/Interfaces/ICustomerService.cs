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
    public interface ICustomerAppService : IAppService<Customer>
    {
        public void Add(string name, string phoneNumber, string password);
        public void UpdateName(int id, string name);
        
    }
}
