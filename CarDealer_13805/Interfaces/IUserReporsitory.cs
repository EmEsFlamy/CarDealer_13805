﻿using CarDealer_13805.Models;

namespace CarDealer_13805.Interfaces
{

    public interface IUserRepository
    {
        public bool CreateUser(User user);
        public User? GetUserById(int id);

        public User? GetUserByCredentials(UserCredential userCredential);

        public bool DeleteUser(int id);
    }
}
