using CarDealer_13805.Interfaces;
using CarDealer_13805.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarDealer_13805.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class OrderController : ControllerBase
    {
        
        
         private readonly IOrderRepository _orderRepository;

    
        public OrderController(IOrderRepository orderRepository
            )
        {
            _orderRepository = orderRepository;
            
        }
        [HttpPost]
        public IActionResult CreateOrder([FromBody] Order order)
        {
            _orderRepository.CreateOrder(order);
            return Ok();
        }

        [HttpGet]
        public IActionResult GetOrderById([FromQuery] int id)
        {
            var order = _orderRepository.GetOrderById(id);
            return Ok(order);
        }
    }
}
