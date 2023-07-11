using CarDealer_13805.Models;

namespace CarDealer_13805.Interfaces
{
    public interface IPaymentRepository
    {
        public void CreatePayment(Payment payment);

        public Payment? GetPaymentById(int id);

        public IEnumerable<PaymentDetails> GetAllUnpaid();

        public void MarkAsPaid(int id);
    }
}
