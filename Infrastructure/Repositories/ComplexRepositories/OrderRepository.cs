using Domain.Entities;
using Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.EntitiesEF;

namespace Infrastructure.Repositories
{
    public class OrderRepository : IOrderRepository<Order>
    {
        private IRepository<OrderEF> _orderRepository;
        private IShoppingCartRepository<ShoppingCart> _shoppingCartRepository;


        public OrderRepository()
        {
            _orderRepository = new Repository<OrderEF>();
            _shoppingCartRepository = new ShoppingCartRepository();
        }

        public OrderRepository(IRepository<OrderEF> orderRepository, IShoppingCartRepository<ShoppingCart> shoppingCartRepository)
        {
            _orderRepository = orderRepository;
            _shoppingCartRepository = shoppingCartRepository;
        }

        public int GetLastID()
        {
            return _orderRepository.GetLastID();
        }

        public Order? GetByID(int id)
        {
            OrderEF? order = _orderRepository.GetByID(id);
            Order res = new Order();
            if (order != null)
            {
                order.Convert(res);
            }
            return res;
        }

        public List<Order>? GetAll()
        {
            List<OrderEF>? ordersEF = _orderRepository.GetAll();
            List<Order> res = new List<Order>();
            
            foreach(OrderEF orderEF in ordersEF)
            {
                Order order = new Order();
                orderEF.Convert(order);
                res.Add(order);
            }

            return res;
        }

        public void Add(Order order)
        {
            _orderRepository.Add(new OrderEF(order));
            _shoppingCartRepository.UpdateOrder(order.ShoppingCart.ID, order.ID);
        }

        public void Update(Order order)
        {
            OrderEF? orderEF = _orderRepository.GetByID(order.ID);
            if (orderEF != null)
            {
                orderEF = new OrderEF(order);
                _orderRepository.Update(orderEF);
            }
            
        }

        public void DeleteByID(int id)
        {
            _orderRepository.DeleteByID(id);
        }
    }
}
