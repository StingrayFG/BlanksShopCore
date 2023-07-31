using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class CustomerRepository<T> : Repository<T> where T: Customer   
    {

        public CustomerRepository(ApplicationContext dbContext): base(dbContext) 
        {
            
        }

    }
}
