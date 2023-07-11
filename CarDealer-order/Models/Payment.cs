using System.Text.Json.Serialization;

namespace CarDealer_13805.Models
{
    public class Payment
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        
        public virtual int UserId { get; set; }
        
        public bool IsPaid { get; set; } = false;
        public int? TotalPrice { get; set; }
    }
}
