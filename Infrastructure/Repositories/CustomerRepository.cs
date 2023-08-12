using Domain.Entities;
using Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.EntitiesEF;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository<Customer>
    {
        public Customer? GetByLogin(string login, string password)
        {
            Customer? res = (from e in _dbContext.Set<Customer>() where (e.PhoneNumber == login) && (e.Password == password) select e).FirstOrDefault();
            return res;
        }

    }
}
