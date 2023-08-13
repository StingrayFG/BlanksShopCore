using Domain.Entities;
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
    public class MetalBlankRepository : IMetalBlankRepository<MetalBlank>
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

        public int GetLastID()
        {
            return _metalBlankRepository.GetLastID();
        }

        public MetalBlank? GetByID(int id)
        {
            MetalBlankEF? metalBlankEF = _metalBlankRepository.GetByID(id);
            if (metalBlankEF != null)
            {
                Material? material = _materialRepository.GetByID(metalBlankEF.MaterialID);
                MetalBlank metalBlank = new MetalBlank();
                if (material != null)
                {
                    metalBlank.UpdateMaterial(material);
                }

                metalBlankEF.Convert(metalBlank);

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
                    MetalBlank metalBlank = new MetalBlank();
                    if(material != null)
                    {
                        metalBlank.UpdateMaterial(material);
                    }

                    metalBlankEF.Convert(metalBlank);
                    
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
            MetalBlankEF? metalBlankEF = _metalBlankRepository.GetByID(metalBlank.ID);
            if (metalBlankEF != null)
            {
                metalBlankEF = new MetalBlankEF(metalBlank);
                _metalBlankRepository.Update(metalBlankEF);
            }

        }

        public void DeleteByID(int id)
        {
            _metalBlankRepository.DeleteByID(id);
        }

    }
}
