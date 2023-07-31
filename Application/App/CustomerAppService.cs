using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Infrastructure.Repositories;

namespace Application.Services
{
    public class CustomerAppService: AppService<Customer>
    {
        public CustomerAppService(Repository<Customer> repo): base(repo)
        {

        }
        public void Add(string name, string phoneNumber, string password)
        {
            Customer res = new Customer(name, phoneNumber, password);
            Repo.Add(res);
        }
    }
}
