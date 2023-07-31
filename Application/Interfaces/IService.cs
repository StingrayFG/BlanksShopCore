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
    public interface IAppService<T> where T : EntityBase
    {
        T? GetByID(int id);
        public List<T>? GetAll();
        public void DeleteByID(int id);

    }
}
