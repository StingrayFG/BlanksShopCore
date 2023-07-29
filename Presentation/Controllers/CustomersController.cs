using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    [ApiController]
    public class CustomersController : Controller
    {
        
        [HttpPut]
        [Route("customers/add")]
        public void AddCustomer()
        {
            
        }

    }
}
