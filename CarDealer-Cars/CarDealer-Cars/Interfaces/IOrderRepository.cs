using CarDealer_Car.Models;

namespace CarDealer_Car.Interfaces
{
    public interface IOrderRepository
    {
        public Order CreateOrder(Order order);

        public Order? GetOrderById(int id);
    }
}
