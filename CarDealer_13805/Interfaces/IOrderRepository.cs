using CarDealer_13805.Models;

namespace CarDealer_13805.Interfaces
{
    public interface IOrderRepository
    {
        public Order CreateOrder(Order order);

        public Order? GetOrderById(int id);
    }
}
