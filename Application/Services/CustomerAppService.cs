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
    public class CustomerAppService: ICustomerAppService
    {
        protected ICustomerRepository<Customer> _repository;

        public CustomerAppService()
        {
            _repository = new CustomerRepository();
        }

        public CustomerAppService(ICustomerRepository<Customer> repository)
        {
            _repository = repository;
        }

        public virtual void SetRepository(ICustomerRepository<Customer> repository)
        {
            _repository = repository;
        }

        public void Add(string name, string phoneNumber, string password)
        {
            Customer res = new Customer(_repository.GetLastID() + 1, name, phoneNumber, password);
            _repository.Add(res);
        }

        public void UpdateName(int id, string name)
        {
            Customer? res = _repository.GetByID(id);
            if (res != null) 
            {
                res.UpdateName(name);
                _repository.Update(res);
            }
            
        }

        public Customer? GetByLogin(string login, string password)
        {
            return _repository.GetByLogin(login, password);
        }

        public virtual Customer? GetByID(int id)
        {
            return _repository.GetByID(id);
        }

        public virtual List<Customer>? GetAll()
        {
            return _repository.GetAll();
        }

        public virtual void DeleteByID(int id)
        {
            _repository.DeleteByID(id);
        }

    }
}
