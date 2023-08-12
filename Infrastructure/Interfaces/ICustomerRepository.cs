﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Infrastructure.Interfaces
{
    public interface ICustomerRepository<T> : IRepository<T> where T : EntityBase
    {
        public Customer? GetByLogin(string login, string password);

    }
}
