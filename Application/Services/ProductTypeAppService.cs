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
    public class ProductTypeAppService : AppService<ProductType>, IProductTypeAppService
    {
        public ProductTypeAppService() { }

        public ProductTypeAppService(IRepository<ProductType> repository) : base(repository)
        {

        }

        public void Add(string name, string description)
        {
            ProductType res = new ProductType(_repository.GetLastID() + 1, name, description);
            _repository.Add(res);
        }

        public void UpdateName(int id, string name)
        {
            ProductType? res = _repository.GetByID(id);
            if (res != null)
            {
                res.UpdateName(name);
                _repository.Update(res);
            }

        }



    }
}
