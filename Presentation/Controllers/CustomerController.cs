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
        public readonly ICustomerService Service;

        public CustomerController(ICustomerService service) 
        {
            Service = service;
        }

        [HttpPost]
        [Route("/add")]
        public void Add(string name, string phoneNumber, string password)
        {
            
        }

        [HttpPut]
        [Route("/update/name")]
        public void UpdateName(int id, string name)
        {
            Service.UpdateName(id, name);
        }

        [HttpPut]
        [Route("/update/phone")]
        public void UpdatePhone(int id, string phone)
        {
            Service.UpdatePhone(id, phone);
        }

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
