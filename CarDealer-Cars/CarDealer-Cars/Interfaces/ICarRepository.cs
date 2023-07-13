using CarDealer_Car.Models.Enums;
using CarDealer_Car.Models;

namespace CarDealer_Car.Interfaces
{
    public interface ICarRepository
    {
        public void CreateCar(Car car);

        public Car? GetCarById(int id);

        public IEnumerable<Car> GetCarsByType(CarTypeEnum carType);

        public bool DeleteCar(int id);
    }
}
