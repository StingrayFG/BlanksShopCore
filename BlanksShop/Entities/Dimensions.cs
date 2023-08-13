using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Dimensions
    {
        public double Width { get; private set; }
        public double Height { get; private set; }
        public double Length { get; private set; }

        public Dimensions() { }

        public Dimensions(double width, double height, double length) 
        { 
            Width = width;
            Height = height;
            Length = length;
        }

        public double CalcVolume()
        { 
            return Width * Height * Length; 
        }

    }
}
