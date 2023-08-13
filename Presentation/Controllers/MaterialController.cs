using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Services;
using Application.Interfaces;
using Domain.Entities;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("material")]
    [ApiExplorerSettings(GroupName = "material")]
    public class MaterialController : Controller
    {
        public readonly IMaterialAppService _service;

        public MaterialController(IMaterialAppService service) 
        {
            _service = service;
        }

        [HttpPost]
        [Route("add")]
        public void Add(string name, double density, decimal pricePerKilogram)
        {
            _service.Add(name, density, pricePerKilogram);
        }

        [HttpPut]
        [Route("update/name")]
        public void UpdateName(int id, string name)
        {
            _service.UpdateName(id, name);
        }

        [HttpGet]
        [Route("get/all")]
        public List<Material>? GetAll()
        {
            return _service.GetAll();
        }

        [HttpGet]
        [Route("get/byid")]
        public Material? GetByID(int id)
        {
            return _service.GetByID(id);
        }

        [HttpDelete]
        [Route("delete/byid")]
        public void DeleteByID(int id)
        {
            _service.DeleteByID(id);
        }
    }
}
