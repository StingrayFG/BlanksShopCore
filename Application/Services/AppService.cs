using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Repositories;

namespace Application.Services
{
    public class AppService<T>: IAppService<T> where T : EntityBase
    {
        protected IRepository<T> _repository;

        public AppService()
        {
            _repository = new Repository<T>();
        }

        public AppService(IRepository<T> repository)
        {
            _repository = repository;
        }

        public virtual void SetRepository(IRepository<T> repository)
        {
            _repository = repository;
        }

        public virtual T? GetByID(int id)
        {
            return _repository.GetByID(id);
        }

        public virtual List<T>? GetAll()
        {
            return _repository.GetAll();
        }

        public virtual void DeleteByID(int id)
        {
            _repository.DeleteByID(id);
        }   
    }
}
