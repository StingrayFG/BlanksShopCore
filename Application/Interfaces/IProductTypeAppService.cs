using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface IProductTypeAppService : IAppService<ProductType>
    {
        public void Add(string name, string decription);
        public void UpdateName(int id, string name);

    }
}
