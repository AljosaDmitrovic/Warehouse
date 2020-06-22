
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
using DataLayer.DataRepositories;
using DataLayer.Models;

namespace BusinessLayer
{
    public class OrderRepositoryBus
    {
        private OrderRepository orderRepository;

        public OrderRepositoryBus()
        {
            this.orderRepository = new OrderRepository();
        }

        public List<Order> GetAllOrders()
        {
            return this.orderRepository.GetAllOrders();
        }
        public Order GetLastOrder()
        {
            return this.orderRepository.GetLastOrder();
        }
        
        public Order GetOrderById(int id)
        {
            return this.orderRepository.GetOrderById(id);
        }
        
        public List<OrderLine> GetAllOrderLines()
        {
            return this.orderRepository.GetAllOrderLines();
        }
        public List<OrderLine> GetAllOrderLinesById(int id)
        {
            return this.orderRepository.GetAllOrderLinesById(id);
        }
        public List<OrderLine> GetAllOrderLinesProductById(int id)
        {
            return this.orderRepository.GetAllOrderLinesProductById(id);
        }

        public bool InsertOrder(Order ord)
        {
            int result = 0;
            if (ord != null)
            {
                result = this.orderRepository.InsertOrder(ord);
            }
            if (result > 0)
            {
                return true;
            }
            return false;
        }
        public bool InsertOrderLine(OrderLine ordLine)
        {
            int result = 0;
            if (ordLine != null)
            {
                result = this.orderRepository.InsertOrderLine(ordLine);
            }
            if (result > 0)
            {
                return true;
            }
            return false;
        }
        

        public bool UpdateOrder(Order ord)
        {
            int result = 0;
            if (ord != null)
            {
                result = this.orderRepository.UpdateOrder(ord);
            }
            if (result > 0)
            {
                return true;
            }
            return false;
        }

        public bool DeleteOrder(int id)
        {
            int result = this.orderRepository.DeleteOrder(id);
            if (result > 0)
            {
                return true;
            }
            return false;
        }
        public bool DeleteAllOrderLines(int OrderId)
        {
            int result = this.orderRepository.DeleteAllOrderLines(OrderId);
            if (result > 0)
            {
                return true;
            }
            return false;
        }
        
    }
}

