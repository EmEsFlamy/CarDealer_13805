using CarDealer_13805.Models.Enums;
using System.Text.Json.Serialization;

namespace CarDealer_13805.Models
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
