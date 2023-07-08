using System.Text.Json.Serialization;

namespace CarDealer_13805.Models
{
    public class User
    {
        public int Id { get; set; }
        
        public string Email { get; set; }
        public string Password { get; set; }
        public int? UserType { get; set; }
        [JsonIgnore]
        public Payment? Payments { get; set; }

        [JsonIgnore]
        public Order? Orders { get; set; }
    }
}
