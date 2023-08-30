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
    [Route("metalblank")]
    [ApiExplorerSettings(GroupName = "metalblank")]
    public class MetalBlankController : Controller
    {
        public readonly IMetalBlankAppService<MetalBlank> _service;

        public MetalBlankController(IMetalBlankAppService<MetalBlank> service) 
        {
            _service = service;
        }

        [HttpPost]
        [Route("add")]
        public void Add(Dimensions dimensions, int materialID, int productTypeID)
        {
            _service.Add(dimensions, materialID, productTypeID);
        }

        [HttpPut]
        [Route("update/producttype")]
        public void UpdateProductType(int id, int productTypeID)
        {
            _service.UpdateProductType(id, productTypeID);
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
