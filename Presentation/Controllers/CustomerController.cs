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
    [Route("customers")]
    [ApiExplorerSettings(GroupName = "customers")]
    public class CustomerController : Controller
    {
        public readonly ICustomerAppService _service;

        public CustomerController(ICustomerAppService service) 
        {
            _service = service;
        }

        [HttpPost]
        [Route("/add")]
        public void Add(string name, string phoneNumber, string password)
        {
            _service.Add(name, phoneNumber, password);
        }

        [HttpPut]
        [Route("/update/name")]
        public void UpdateName(int id, string name)
        {
            _service.UpdateName(id, name);
        }

        [HttpGet]
        [Route("/get/all")]
        public List<Customer>? GetAll()
        {
            return _service.GetAll();
        }

        [HttpGet]
        [Route("/get/byid")]
        public Customer? GetByID(int id)
        {
            return _service.GetByID(id);
        }

        [HttpDelete]
        [Route("/delete/byid")]
        public void DeleteByID(int id)
        {
            _service.DeleteByID(id);
        }
    }
}
