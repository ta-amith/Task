using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task1.Entities;

namespace Task1.Interfaces
{
    public interface IOrderRepository
    {
        Task<Order> CreateAsync(Order order);

        Task<IReadOnlyList<Order>> GetOrders();

        Task<Order> GetOrder(string id);

        Task UpdateAsync(Order order,string id);

        Task<string> GetOrdersByYear(int year);

    }
}
