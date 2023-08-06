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
    public interface IMetalBlankRepository<T> where T : MetalBlank
    {
        public T? GetByID(int id);
        public List<T>? GetAll();
        public void Add(T entity);
        public void Update(T entity);
        public void Delete(T entity);
        public void DeleteByID(int id);

    }
}
