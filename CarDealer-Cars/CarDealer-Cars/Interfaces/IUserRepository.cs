using CarDealer_Cars.Interfaces.DTO;

namespace CarDealer_Cars.Interfaces
{
    public interface IUserRepository
    {
        public UserDTO GetUserInfo(int id, string access_token);
    }
}
