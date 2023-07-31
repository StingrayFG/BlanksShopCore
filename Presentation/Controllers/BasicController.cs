using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Services;
using Domain.Entities;

namespace Presentation.Controllers
{
    [ApiController]
    public class BasicController : Controller
    {
        private AppService<EntityBase> Service;      

        [HttpGet]
        [Route("/get/all")]
        public void GetAll()
        {
            Service.GetAll();
        }

        [HttpGet]
        [Route("/get/byid")]
        public void GetByID(int id)
        {
            Service.GetByID(id);
        }

        [HttpDelete]
        [Route("/delete/byid")]
        public void DeleteByID(int id)
        {
            Service.DeleteByID(id);
        }
    }
}
