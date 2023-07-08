using CarDealer_13805.Models;

namespace CarDealer_13805.Interfaces
{
    public interface ITokenRepository
    {
        public string CreateToken(User user);
    }
}
