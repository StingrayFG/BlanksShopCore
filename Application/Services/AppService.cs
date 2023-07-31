using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Interfaces;
using Infrastructure.Repositories;

namespace Application.Services
{
    public class AppService<T>: IService<T> where T : EntityBase
    {
        protected IRepository<T> Repo;

        public AppService(Repository<T> repo)
        {
            Repo = repo;
        }

        public void SetRepository(Repository<T> repo)
        {
            Repo = repo;
        }

        public virtual T? GetByID(int id)
        {
            return Repo.GetByID(id);
        }

        public virtual List<T>? GetAll()
        {
            return Repo.GetAll();
        }

        public virtual void DeleteByID(int id)
        {
            Repo.DeleteByID(id);
        }
    }
}
