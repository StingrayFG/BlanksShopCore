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
    [Route("shoppingcart")]
    [ApiExplorerSettings(GroupName = "shoppingcart")]
    public class ShoppingCartController : Controller
    {
        public readonly IShoppingCartAppService<ShoppingCart> _service;

        public ShoppingCartController(IShoppingCartAppService<ShoppingCart> service) 
        {
            _service = service;
        }

        [HttpPost]
        [Route("add/product")]
        public void AddProduct(int customerID, int productID)
        {
            _service.AddProduct(customerID, productID);
        }

        [HttpDelete]
        [Route("delete/product")]
        public void DeleteProductByID(int customerID, int productID)
        {
            _service.DeleteProductByID(customerID, productID);
        }

        [HttpGet]
        [Route("get/all")]
        public List<ShoppingCart>? GetAll()
        {
            return _service.GetAll();
        }

        [HttpGet]
        [Route("get/bycustomer")]
        public List<ShoppingCart>? GetByCustomer(int customerID)
        {
            return _service.GetByCustomer(customerID);
        }

        [HttpGet]
        [Route("get/currentbycustomer")]
        public ShoppingCart? GetCurrentByCustomer(int customerID)
        {
            return _service.GetCurrentByCustomer(customerID);
        }

        [HttpGet]
        [Route("get/byid")]
        public ShoppingCart? GetByID(int id)
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
