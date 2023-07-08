﻿using CarDealer_13805.Interfaces;
using CarDealer_13805.Models.Enums;
using CarDealer_13805.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarDealer_13805.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CarController : ControllerBase
    {
        private readonly ICarRepository _carRepository;

        public CarController(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }
        [HttpPost]
        public IActionResult CreateCar([FromBody] Car car)
        {
            _carRepository.CreateCar(car);
            return Ok();
        }
        [HttpGet]
        public IActionResult GetCarById(int id)
        {
            var car = _carRepository.GetCarById(id);
            if (car is null) return BadRequest("Car does not exist!");
            return Ok(car);
        }
        [HttpGet("getCarsByType")]
        public IActionResult GetCarsByType(CarTypeEnum carType)
        {
            var cars = _carRepository.GetCarsByType(carType);
            return Ok(cars);
        }
    }
}
