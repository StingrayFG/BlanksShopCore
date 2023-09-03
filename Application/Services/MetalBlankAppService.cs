using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Repositories;

namespace Application.Services
{
    public class MetalBlankAppService : IMetalBlankAppService<MetalBlank>
    {
        protected IMetalBlankRepository<MetalBlank> _repository;
        protected IRepository<Material> _materialsRepository;
        protected IRepository<ProductType> _productTypeRepository;

        public MetalBlankAppService()
        {
            _repository = new MetalBlankRepository();
            _materialsRepository = new Repository<Material>();
            _productTypeRepository = new Repository<ProductType>();
        }

        public MetalBlankAppService(IMetalBlankRepository<MetalBlank> repository, IRepository<Material> materialsRepository, IRepository<ProductType> productTypeRepository)
        {
            _repository = repository;
            _materialsRepository = materialsRepository;
            _productTypeRepository = productTypeRepository;
        }

        public void Add(Dimensions dimensions, int materialID, int productTypeID)
        {
            Material? material = _materialsRepository.GetByID(materialID);
            ProductType? productType = _productTypeRepository.GetByID(productTypeID);
            if ((material != null) && (productType != null))
            {
                MetalBlank res = new MetalBlank(_repository.GetLastID() + 1,  dimensions, material, productType);
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


        public void UpdateProductType(int id, int productTypeID)
        {
            ProductType? productType = _productTypeRepository.GetByID(productTypeID);
            MetalBlank? res = _repository.GetByID(id);
            if ((productType != null) && (res != null))
            {
                res.UpdateProductType(productType);
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
