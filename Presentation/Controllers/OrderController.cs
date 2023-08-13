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
    [Route("order")]
    [ApiExplorerSettings(GroupName = "order")]
    public class OrderController : Controller
    {
        public readonly IOrderAppService<Order> _service;

        public OrderController(IOrderAppService<Order> service) 
        {
            _service = service;
        }

        [HttpPost]
        [Route("add")]
        public void Add(int customerID, string paymentMethod)
        {
            _service.Add(customerID, paymentMethod);
        }

        [HttpPut]
        [Route("update/payment")]
        public void UpdatePayment(int id, string payment)
        {
            _service.UpdatePayment(id, payment);
        }

        [HttpGet]
        [Route("get/all")]
        public List<Order>? GetAll()
        {
            return _service.GetAll();
        }

        [HttpGet]
        [Route("get/byid")]
        public Order? GetByID(int id)
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
