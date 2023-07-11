using CarDealer_Car.Interfaces;
using CarDealer_Car.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Security.Claims;

namespace CarDealer_Car.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentRepository _paymentRepository;

        public PaymentController(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }
        [HttpPost]
        public IActionResult CreatePayment([FromBody] Payment payment)
        {
            var claimsIdentity = HttpContext.User.Identity as ClaimsIdentity;
            var userid = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            _paymentRepository.CreatePayment(payment);
            return Ok();
        }
        [HttpGet]
        [Authorize(Roles = "1")]
        public IActionResult GetPaymentById([FromQuery] int id)
        {
            var payment = _paymentRepository.GetPaymentById(id);
            if (payment is null) return BadRequest("Payment does not exist!");
            return Ok(payment);
        }

        [HttpGet("GetAllUnpaid")]
        [Authorize(Roles = "1")]
        public IActionResult GetAllUnpaid()
        {
            var payments = _paymentRepository.GetAllUnpaid();
            return Ok(payments);
        }

        [HttpPost("MarkAsPaid")]
        [Authorize(Roles = "1")]
        public IActionResult MarkAsPaid([FromBody] VerifyPayment verifyPayment)
        {
            _paymentRepository.MarkAsPaid(verifyPayment.Id);
            return Ok();
        }
    }
}

