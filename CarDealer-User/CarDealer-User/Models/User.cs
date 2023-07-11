using System.Text.Json.Serialization;

namespace CarDealer_User.Models
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

        

        
    }
}
