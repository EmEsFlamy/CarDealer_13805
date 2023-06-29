using CarDealer_13805.Models;

namespace CarDealer_13805
{
    
    public interface IUserRepository
    {
        public void CreateUser(User user);
        public User? UserGetUserById(int id);

        public User? GetUserByCredentials(UserCredential userCredential);


    }
}
