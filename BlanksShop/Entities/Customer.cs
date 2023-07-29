﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    public class Customer: EntityBase
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }

    }
}
