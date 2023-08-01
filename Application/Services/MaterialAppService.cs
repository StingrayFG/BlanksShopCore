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
    public class MaterialAppService : AppService<Material>, IMaterialAppService
    {
        public MaterialAppService() { }

        public MaterialAppService(IRepository<Material> repository) : base(repository)
        {

        }

        public void Add(string name, double density, decimal pricePerKilogram)
        {
            Material res = new Material(name, density, pricePerKilogram);
            _repository.Add(res);
        }

        public void UpdateName(int id, string name)
        {
            Material? res = _repository.GetByID(id);
            if (res != null)
            {
                res.UpdateName(name);
                _repository.Update(res);
            }

        }



    }
}
