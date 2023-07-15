namespace CarDealer_Car.Models
{
    public class PaymentDetails
    {
        public int Id { get; set; }
        public bool IsPaid { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Mark { get; set; }
        public string Model { get; set; }
        public int TotalPrice { get; set; }
        public int UserId { get; set; } 
    }
}
