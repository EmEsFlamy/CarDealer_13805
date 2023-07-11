using System.Text.Json.Serialization;

namespace CarDealer_Car.Models
{
    public class Payment
    {
        public int Id { get; set; }
        public virtual int OrderId { get; set; }
        [JsonIgnore]
        public Order? Order { get; set; }
        public int UserId { get; set; }
        
        public bool IsPaid { get; set; } = false;
        public int? TotalPrice { get; set; }
    }
}
