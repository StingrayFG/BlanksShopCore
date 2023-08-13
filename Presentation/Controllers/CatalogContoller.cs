using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Services;
using Application.Interfaces;
using Domain.Entities;
using Application.EntitiesUI;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("catalog")]
    [ApiExplorerSettings(GroupName = "catalog")]
    public class CatalogController : Controller
    {
        public readonly ICatalogAppService<ProductCard> _service;

        public CatalogController(ICatalogAppService<ProductCard> service) 
        {
            _service = service;
        }

        [HttpGet]
        [Route("get/all")]
        public List<ProductCard>? GetAll()
        {
            return _service.GetAll();
        }

    }
}
