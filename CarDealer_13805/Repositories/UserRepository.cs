﻿using CarDealer_13805.Database;
using CarDealer_13805.Models.Enums;
using CarDealer_13805.Models;

namespace CarDealer_13805.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public void CreateUser(User user)
        {
            user.UserType = (int)UserTypeEnum.User;
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public User? GetUserByCredentials(UserCredential userCredential)
        {
            var user = _context.Users.FirstOrDefault(x => x.Email == userCredential.Email);
            if (user is null) return null;
            if (user.Password != userCredential.Password) return null;
            return user;
        }

        public User? UserGetUserById(int id)
        {
            var user = _context.Users.FirstOrDefault(x => x.Id == id);
            return user;
        }
    }
}
