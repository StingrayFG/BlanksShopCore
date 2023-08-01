using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Services;
using Application.Interfaces;
using Domain.Entities;
using System.Numerics;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("metalblanks")]
    [ApiExplorerSettings(GroupName = "metalblanks")]
    public class MetalBlankController : Controller
    {
        public readonly IMetalBlankAppService _service;

        public MetalBlankController(IMetalBlankAppService service) 
        {
            _service = service;
        }

        [HttpPost]
        [Route("add")]
        public void Add(string name, Vector3 dimensions, int materialID)
        {
            _service.Add(name, dimensions, materialID);
        }

        [HttpPut]
        [Route("update/name")]
        public void UpdateName(int id, string name)
        {
            _service.UpdateName(id, name);
        }

        [HttpPut]
        [Route("update/material")]
        public void UpdateMaterial(int id, int materialID)
        {
            _service.UpdateMaterial(id, materialID);
        }

        [HttpGet]
        [Route("get/all")]
        public List<MetalBlank>? GetAll()
        {
            return _service.GetAll();
        }

        [HttpGet]
        [Route("get/byid")]
        public MetalBlank? GetByID(int id)
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
