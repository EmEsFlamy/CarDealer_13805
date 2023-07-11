﻿using CarDealer_Car.Database;
using CarDealer_Car.Interfaces;
using CarDealer_Car.Models;

namespace CarDealer_Car.Reporsitories
{
    
        public class PaymentRepository : IPaymentRepository
        {
            private readonly ApplicationDbContext _context;

            public PaymentRepository(ApplicationDbContext context)
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

