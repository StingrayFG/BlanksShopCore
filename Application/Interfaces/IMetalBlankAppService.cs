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
    public interface IMetalBlankAppService : IAppService<MetalBlank>
    {
        public void Add(string name, Vector3 dimensions, int materialID);
        public void UpdateName(int id, string name);
        public void UpdateMaterial(int id, int materialID);

    }
}

