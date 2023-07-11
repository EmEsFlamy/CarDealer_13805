using CarDealer_User.Models;

namespace CarDealer_User.Interfaces
{

    public interface IUserRepository
    {
        public bool CreateUser(User user);
        public User? GetUserById(int id);

        public User? GetUserByCredentials(UserCredential userCredential);

        public bool DeleteUser(int id);
    }
}
