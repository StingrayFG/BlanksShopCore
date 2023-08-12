using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Interfaces;
using Infrastructure.Repositories;

namespace Application.Services
{
    public class OrderAppService : IOrderAppService<Order>
    {
        protected IOrderRepository<Order> _orderRepository;
        protected IShoppingCartRepository<ShoppingCart> _shoppingCartRepository;

        public OrderAppService() 
        {
            _orderRepository = new OrderRepository();
            _shoppingCartRepository = new ShoppingCartRepository();
        }

        public OrderAppService(IOrderRepository<Order> orderRepository, IShoppingCartRepository<ShoppingCart> shoppingCartRepository)
        {
            _orderRepository = orderRepository;
            _shoppingCartRepository = shoppingCartRepository;
        }

        public void Add(int customerID)
        {
            ShoppingCart? shoppingCart = _shoppingCartRepository.GetCurrentByCustomer(customerID);
            if (shoppingCart != null)
            {
                Order res = new Order(_orderRepository.GetLastID() + 1, customerID, shoppingCart);
                _orderRepository.Add(res);
            }       
        }

        public Order? GetByID(int id)
        {
            return _orderRepository.GetByID(id);
        }

        public List<Order>? GetAll()
        {
            return _orderRepository.GetAll();
        }

        public void UpdatePayment(int id, string payment)
        {
            Order? order = _orderRepository.GetByID(id);
            if (order != null) 
            {
                order.UpdatePayment(payment);
                _orderRepository.Update(order);
            }
        }

        public void DeleteByID(int id)
        {
            _orderRepository.DeleteByID(id);
        }


    }
}
