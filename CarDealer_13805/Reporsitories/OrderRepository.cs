using CarDealer_13805.Database;
using CarDealer_13805.Interfaces;
using CarDealer_13805.Models;
using System.Net.Mime;
using Microsoft.AspNetCore.Hosting.Builder;

namespace CarDealer_13805.Reporsitories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext _context;

        public OrderRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Order CreateOrder(Order order)
        {
            _context.Orders.Add(order);
            _context.SaveChanges();
            return order;
        }

        public Order? GetOrderById(int id)
        {
            var order = _context.Orders.FirstOrDefault(o => o.Id == id);
            return order;
        }
    }
}
