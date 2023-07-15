using CarDealer_Car.Models;
using CarDealer_Cars.Interfaces.DTO;

namespace CarDealer_Car.Interfaces
{
    public interface IPaymentRepository
    {
        public void CreatePayment(Payment payment);

        public Payment? GetPaymentById(int id);

        public IEnumerable<PaymentDetailsDTO> GetAllUnpaid(string access_token);

        public void MarkAsPaid(int id);
    }
}
