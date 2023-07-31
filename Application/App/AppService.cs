using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Infrastructure.Interfaces;
using Infrastructure.Repositories;

namespace Application.Services
{
    public class AppService<T> where T : EntityBase
    {
        protected Repository<T> Repo;

        public AppService(Repository<T> repo)
        {
            Repo = repo;
        }

        [System.ComponentModel.DataObjectMethod
        (System.ComponentModel.DataObjectMethodType.Select, true)]

        public virtual T? GetByID(int id)
        {
            return Repo.GetByID(id);
        }

        public virtual List<T>? GetAll()
        {
            return Repo.GetAll();
        }

        public virtual void Delete(T entity)
        {
            Repo.Delete(entity);
        }

        public virtual void DeleteByID(int id)
        {
            Repo.DeleteByID(id);
        }
    }
}
