using CarDealer_13805.Models.Enums;
using CarDealer_13805.Models;

namespace CarDealer_13805.Interfaces
{
    public interface ICarRepository
    {
        public void CreateCar(Car car);

        public Car? GetCarById(int id);

        public IEnumerable<Car> GetCarsByType(CarTypeEnum carType);


    }
}
