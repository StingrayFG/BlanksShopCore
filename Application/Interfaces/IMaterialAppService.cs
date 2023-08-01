using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface IMaterialAppService : IAppService<Material>
    {
        public void Add(string name, double density, decimal pricePerKilogram);
        public void UpdateName(int id, string name);
        
    }
}
