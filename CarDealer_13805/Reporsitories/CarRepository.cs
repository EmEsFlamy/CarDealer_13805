﻿using CarDealer_13805.Database;
using CarDealer_13805.Interfaces;
using CarDealer_13805.Models.Enums;
using CarDealer_13805.Models;

namespace CarDealer_13805.Reporsitories
{
    public class CarRepository : ICarRepository
    {
        private readonly ApplicationDbContext _context;

        public CarRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public void CreateCar(Car car)
        {
            _context.Cars.Add(car);
            _context.SaveChanges();
        }

        public Car GetCarById(int id)
        {
            var car = _context.Cars.FirstOrDefault(c => c.Id == id);
            return car;
        }

        public IEnumerable<Car> GetCarsByType(CarTypeEnum carType)
        {
            var cars = _context.Cars.Where(x => x.CarType == carType).AsEnumerable();
            if (cars is null) return Enumerable.Empty<Car>();
            return cars;
        }
    }
}
