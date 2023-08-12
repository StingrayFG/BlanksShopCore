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
    public class MetalBlankAppService : IMetalBlankAppService<MetalBlank>
    {
        protected IMetalBlankRepository<MetalBlank> _repository;
        protected IRepository<Material> _materialsRepository;

        public MetalBlankAppService()
        {
            _repository = new MetalBlankRepository();
            _materialsRepository = new Repository<Material>();
        }

        public MetalBlankAppService(IMetalBlankRepository<MetalBlank> repository, IRepository<Material> materialsRepository)
        {
            _repository = repository;
            _materialsRepository = materialsRepository;
        }

        public void Add(string name, Dimensions dimensions, int materialID)
        {
            Material? material = _materialsRepository.GetByID(materialID);
            if (material != null) 
            {
                MetalBlank res = new MetalBlank(_repository.GetLastID() + 1, name, dimensions, material);
                _repository.Add(res);
            }     
        }


        public virtual MetalBlank? GetByID(int id)
        {
            return _repository.GetByID(id);
        }

        public virtual List<MetalBlank>? GetAll()
        {
            return _repository.GetAll();
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

        public virtual void DeleteByID(int id)
        {
            _repository.DeleteByID(id);
        }
    }
}
