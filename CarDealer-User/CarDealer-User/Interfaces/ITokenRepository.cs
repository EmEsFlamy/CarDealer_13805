using CarDealer_User.Models;

namespace CarDealer_User.Interfaces
{
    public interface ITokenRepository
    {
        public string CreateToken(User user);
    }
}
