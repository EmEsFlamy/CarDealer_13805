using CarDealer_13805.Database;
using CarDealer_13805.Models.Enums;
using CarDealer_13805.Models;
using CarDealer_13805.Interfaces;
using CarDealer_13805.Helpers;

namespace CarDealer_13805.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly EncodeHelper _encodeHelper;

        public UserRepository(ApplicationDbContext context)
        {
            _encodeHelper = EncodeHelper.Instance();
            _context = context;
        }
        public void CreateUser(User user)
        {
            user.Password = _encodeHelper.Encode(user.Password);
            user.UserType = (int)UserTypeEnum.User;
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public bool DeleteUser(int id)
        {
            var user = GetUserById(id);
            if (user is null) return false;
            _context.Users.Remove(user);
            _context.SaveChanges();
            return true;
        }

        public User? GetUserByCredentials(UserCredential userCredential)
        {
            var user = _context.Users.FirstOrDefault(x => x.Email == userCredential.Email);
            if (user is null) return null;
            var credentialPasswordHash = _encodeHelper.Encode(userCredential.Password);
            if (_encodeHelper.Verify(user.Password, credentialPasswordHash)) return null;
            return user;
        }

        public User? GetUserById(int id)
        {
            var user = _context.Users.FirstOrDefault(x => x.Id == id);
            return user;
        }
    }
}
