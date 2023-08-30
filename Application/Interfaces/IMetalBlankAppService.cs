using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface IMetalBlankAppService<T>
    {     
        public T? GetByID(int id);
        public List<T>? GetAll();
        public void DeleteByID(int id);
        public void Add(Dimensions dimensions, int materialID, int productTypeID);
        public void UpdateProductType(int id, int productTypeID);
        public void UpdateMaterial(int id, int materialID);

    }
}

