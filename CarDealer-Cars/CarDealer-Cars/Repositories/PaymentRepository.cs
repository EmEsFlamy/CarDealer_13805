using CarDealer_Car.Database;
using CarDealer_Car.Interfaces;
using CarDealer_Car.Models;
using CarDealer_Cars.Interfaces;
using CarDealer_Cars.Interfaces.DTO;
using CarDealer_Cars.Repositories;

namespace CarDealer_Car.Reporsitories
{

    public class PaymentRepository : IPaymentRepository
        {
            private readonly ApplicationDbContext _context;
            private readonly IUserRepository _userRepository;
        

            public PaymentRepository(ApplicationDbContext context, IUserRepository userRepository)
            {
                _context = context;
                _userRepository= userRepository;
            }

            public void CreatePayment(Payment payment)
            {
                _context.Payments.Add(payment);
                _context.SaveChanges();
            }

            public IEnumerable<PaymentDetailsDTO> GetAllUnpaid(string access_token)
            {
                
                var payments = _context.PaymentsDetails.Where(x => !x.IsPaid).AsEnumerable();
                if (payments is null) return Enumerable.Empty<PaymentDetailsDTO>();
                return  payments.Select(it =>
                {
                    var user = _userRepository.GetUserInfo(it.UserId, access_token);
                    return new PaymentDetailsDTO(it, user.Name, user.Surname);
                }); 
            }

            public Payment? GetPaymentById(int id)
            {
                var payment = _context.Payments.FirstOrDefault(p => p.Id == id);
                return payment;
            }

            public void MarkAsPaid(int id)
            {
                var payment = GetPaymentById(id);
                payment.IsPaid = true;
                _context.SaveChanges();
            }

        
    }
    }

