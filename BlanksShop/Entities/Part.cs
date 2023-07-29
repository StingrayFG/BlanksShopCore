using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    public class Part: Product
    {
        public decimal ManufacturingCost { get; set; }

    }
}
