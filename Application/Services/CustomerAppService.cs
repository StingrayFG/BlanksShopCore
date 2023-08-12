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
    public class CustomerAppService: AppService<Customer>, ICustomerAppService
    {
        public CustomerAppService() { }

        public CustomerAppService(IRepository<Customer> repository): base(repository)
        {
            
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

        

    }
}
