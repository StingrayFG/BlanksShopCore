using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class Repository<T> : IRepository<T> where T : EntityBase
    {
        protected ApplicationContext _dbContext;

        public Repository()
        {
            _dbContext = new ApplicationContext(); 
        }

        public Repository(ApplicationContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void SetContext(ApplicationContext dbContext)
        {
            _dbContext = dbContext; 
        }

        public virtual int GetLastID()
        {
            return _dbContext.Set<T>().Max(entity => entity.ID);
        }

        public virtual T? GetByID(int id)
        {
            return _dbContext.Set<T>().Find(id);
        }

        public virtual List<T>? GetAll()
        {
            return _dbContext.Set<T>().ToList();
        }

        public virtual List<T>? GetByQuery(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            return _dbContext.Set<T>()
                   .Where(predicate)
                   .ToList();
        }

        public void Add(T entity)
        { 
            _dbContext.Set<T>().Add(entity);
            _dbContext.SaveChanges();
        }

        public void Update(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }

        public void Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            _dbContext.SaveChanges();
        }

        public void DeleteByID(int id)
        {
            T? entity = _dbContext.Set<T>().Find(id);
            if (entity != null)
            {
                _dbContext.Set<T>().Remove(entity);
                _dbContext.SaveChanges();
            }
        }

    }
}
