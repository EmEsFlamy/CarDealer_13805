using CarDealer_Car.Models;

namespace CarDealer_Car.Interfaces
{
    public interface IPaymentRepository
    {
        public void CreatePayment(Payment payment);

        public Payment? GetPaymentById(int id);

        public IEnumerable<PaymentDetails> GetAllUnpaid();

        public void MarkAsPaid(int id);
    }
}
