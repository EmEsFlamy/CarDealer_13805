using CarDealer_Car.Models.Enums;
using System.Text.Json.Serialization;

namespace CarDealer_Car.Models
{
    public class Car
    {
        public int Id { get; set; }
        public CarTypeEnum CarType { get; set; }
        public string Mark { get; set; }
        public string Model { get; set; }
        public double Price { get; set; }

        [JsonIgnore]
        public List<Order>? Orders { get; set; }
    }
}
