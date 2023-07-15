using CarDealer_Car.Models;

namespace CarDealer_Cars.Interfaces.DTO
{
    public class PaymentDetailsDTO
    {
        public PaymentDetailsDTO(PaymentDetails paymentDetails, string name, string surname)
        {
            Id = paymentDetails.Id;
            IsPaid = paymentDetails.IsPaid;
            StartDate = paymentDetails.StartDate;
            EndDate = paymentDetails.EndDate;
            Mark = paymentDetails.Mark;
            Model = paymentDetails.Model;
            TotalPrice = paymentDetails.TotalPrice;
            Name = name;
            Surname = surname;
        }

        public int Id { get; }
        public bool IsPaid { get; }
        public DateTime StartDate { get; }
        public DateTime EndDate { get; }
        public string Mark { get; }
        public string Model { get; }
        public int TotalPrice { get; }
        public string Name { get; }
        public string Surname { get; }
    }
}
