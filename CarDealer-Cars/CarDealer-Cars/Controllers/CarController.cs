using CarDealer_Car.Interfaces;
using CarDealer_Car.Models.Enums;
using CarDealer_Car.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarDealer_Car.Controllers
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
        [Authorize(Roles = "1")]
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

        [HttpDelete]
        [Authorize(Roles = "1")]
        public IActionResult DeleteCar(int id)
        {
            var deletedcar = _carRepository.DeleteCar(id);
            if (!deletedcar) return BadRequest("Car cannot be found");
            return Ok();
        }
    }
}
