using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMvc.Models.OrderModels;

namespace WebMvc.Services
{
    public interface IOrderService
    {
        Task<Order> GetOrder(string orderId);
        Task<int> CreateOrder(Order order);
    }
}
