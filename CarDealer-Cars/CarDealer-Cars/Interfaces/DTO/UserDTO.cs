using System.Text.Json.Serialization;

namespace CarDealer_Cars.Interfaces.DTO
{
    public class UserDTO
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
        
        public string Surname { get; set; }
        
        public string Email { get; set; }
        
        public string Password { get; set; }
        public int? UserType { get; set; }
    }
}
