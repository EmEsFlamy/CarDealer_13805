using System.Text.Json.Serialization;

namespace CarDealer_13805.Models
{
    public class User
    {
        public int Id { get; set; }
        [JsonRequired]
        public string Name { get; set; }
        [JsonRequired]
        public string Surname { get; set; }
        [JsonRequired]
        public string Email { get; set; }
        [JsonRequired]
        public string Password { get; set; }
        public int? UserType { get; set; }

        [JsonIgnore]
        public List<Payment>? Payments { get; set; }

        [JsonIgnore]
        public List<Order>? Orders { get; set; }
    }
}
