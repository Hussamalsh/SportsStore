using SportStore.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SportsStore.Data
{
    public interface IOrderRepository
    {
        IEnumerable<Order> Orders { get; }
        void SaveOrder(Order order);
    }
}
