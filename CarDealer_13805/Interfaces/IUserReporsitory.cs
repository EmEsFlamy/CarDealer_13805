using CarDealer_13805.Models;

namespace CarDealer_13805.Interfaces
{

    public interface IUserReporsitory
    {
        public void CreateUser(User user);
        public User? UserGetUserById(int id);

        public User? GetUserByCredentials(UserCredential userCredential);


    }
}
