using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ProductType : EntityBase
    {
        public string Name { get; protected set; }
        public string? Description { get; protected set; }

        public ProductType() { }
    }
}
