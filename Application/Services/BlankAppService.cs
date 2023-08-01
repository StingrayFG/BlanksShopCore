using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Interfaces;
using Infrastructure.Repositories;

namespace Application.Services
{
    public class BlankAppService : AppService<MetalBlank>, IBlankAppService
    {
        IRepository<Material> _materialsRepository;

        public BlankAppService() : base()
        {
            _materialsRepository = new Repository<Material>();
        }

        public BlankAppService(IRepository<MetalBlank> repository, IRepository<Material> materialsRepository) : base(repository)
        {
            _materialsRepository = materialsRepository;
        }

        public void Add(string name, Vector3 dimensions, int materialID)
        {
            Material? material = _materialsRepository.GetByID(materialID);
            if (material != null) 
            {
                MetalBlank res = new MetalBlank(name, dimensions, material);
                _repository.Add(res);
            }     
        }

        public void UpdateName(int id, string name)
        {
            MetalBlank? res = _repository.GetByID(id);
            if (res != null)
            {
                res.UpdateName(name);
                _repository.Update(res);
            }

        }

        public void UpdateMaterial(int id, int materialID)
        {
            Material? material = _materialsRepository.GetByID(materialID);
            MetalBlank? res = _repository.GetByID(id);
            if ((material != null) && (res != null))
            {
                res.UpdateMaterial(material);
                _repository.Update(res);
            }

        }
    }
}
