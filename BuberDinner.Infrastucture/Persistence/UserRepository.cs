﻿using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Domain.UserAggrerate.Entities;

namespace BuberDinner.Infrastucture.Persistence
{
    public class UserRepository : IUserRepository
    {
        private static readonly List<User> _users = new();

        public void Add(User user)
        {
            _users.Add(user);
        }

        public User? GetUserByEmail(string email)
        {
            return _users.FirstOrDefault(x => x.Email == email);
        }
    }
}
