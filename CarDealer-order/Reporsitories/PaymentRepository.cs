using CarDealer_13805.Database;
using CarDealer_13805.Interfaces;
using CarDealer_13805.Models;

namespace CarDealer_13805.Reporsitories
{
    
        public class PaymentRepository : IPaymentRepository
        {
            private readonly ApplicationDbContext1 _context;

            public PaymentRepository(ApplicationDbContext1 context)
            {
                _context = context;

            }

            public void CreatePayment(Payment payment)
            {
                _context.Payments.Add(payment);
                _context.SaveChanges();
            }

            public IEnumerable<PaymentDetails> GetAllUnpaid()
            {
                var payments = _context.PaymentsDetails.Where(x => !x.IsPaid).AsEnumerable();
                if (payments is null) return Enumerable.Empty<PaymentDetails>();
                return payments;
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

