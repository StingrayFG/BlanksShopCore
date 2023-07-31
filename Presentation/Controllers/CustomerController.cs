using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Services;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("customers")]
    [ApiExplorerSettings(GroupName = "customers")]
    public class CustomerController : BasicController
    {
        private CustomerAppService Service;
            
        [HttpPost]
        [Route("/add")]
        public void Add(string name, string phoneNumber, string password)
        {
            Service.Add(name, phoneNumber, password);
        }

        [HttpPut]
        [Route("/update/name")]
        public void UpdateName(int id, string name)
        {

        }
    }
}
