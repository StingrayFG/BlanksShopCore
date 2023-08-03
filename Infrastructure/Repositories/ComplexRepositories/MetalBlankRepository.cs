﻿using Domain.Entities;
using Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.EntitiesEF;

namespace Infrastructure.Repositories
{
    public class MetalBlankRepository : IRepository<MetalBlank>
    {
        private IRepository<MetalBlankEF> _metalBlankRepository;
        private IRepository<Material> _materialRepository;


        public MetalBlankRepository()
        {
            _metalBlankRepository = new Repository<MetalBlankEF>();
            _materialRepository = new Repository<Material>();
        }

        public MetalBlankRepository(IRepository<MetalBlankEF> metalBlankRepository, IRepository<Material> materialRepository)
        {
            _metalBlankRepository = metalBlankRepository;
            _materialRepository = materialRepository;
        }

        public void Add(MetalBlank metalBlank)
        {
            MetalBlankEF metalBlankEF = new MetalBlankEF(metalBlank);
            _metalBlankRepository.Add(metalBlankEF);
        }

        public MetalBlank? GetByID(int id)
        {
            MetalBlankEF? metalBlankEF = _metalBlankRepository.GetByID(id);
            if (metalBlankEF != null)
            {
                Material? material = _materialRepository.GetByID(metalBlankEF.MaterialID);
                MetalBlank metalBlank = metalBlankEF.Convert(material);
                return metalBlank;
            }
            else
            {
                return null;
            }
        }

        public List<MetalBlank>? GetAll()
        {
            List<MetalBlankEF>? metalBlanksEF = _metalBlankRepository.GetAll();
            if (metalBlanksEF != null)
            {
                List<MetalBlank> res = new List<MetalBlank>();
                foreach (MetalBlankEF metalBlankEF in metalBlanksEF)
                {
                    Material? material = _materialRepository.GetByID(metalBlankEF.MaterialID);
                    MetalBlank metalBlank = metalBlankEF.Convert(material);
                    res.Add(metalBlank);
                }
                return res;
            }
            else
            {
                return null;
            }
        }

        public void Update(MetalBlank metalBlank)
        {
            MetalBlankEF metalBlankEF = new MetalBlankEF(metalBlank);
            _metalBlankRepository.Update(metalBlankEF);
        }

        public void Delete(MetalBlank metalBlank)
        {
            MetalBlankEF metalBlankEF = new MetalBlankEF(metalBlank);
            _metalBlankRepository.Delete(metalBlankEF);
        }

        public void DeleteByID(int id)
        {
            _metalBlankRepository.DeleteByID(id);
        }

    }
}