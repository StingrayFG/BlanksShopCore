using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Repositories;

namespace Application.Services
{
    public class CustomerAppService: AppService<Customer>, ICustomerService
    {
        public CustomerAppService(Repository<Customer> repo): base(repo)
        {
            
        }

        public void Add(string name, string phoneNumber, string password)
        {
            Customer res = new Customer(name, phoneNumber, password);
            Repo.Add(res);
        }

        public void UpdateName(int id, string name)
        {
            Customer? res = Repo.GetByID(id);
            if (res != null) 
            {
                res.Name = name;
                Repo.Update(res);
            }
            
        }

        public void UpdatePhone(int id, string phone)
        {
            Customer? res = Repo.GetByID(id);
            if (res != null)
            {
                res.PhoneNumber = phone;
                Repo.Update(res);
            }
            
        }
    }
}
