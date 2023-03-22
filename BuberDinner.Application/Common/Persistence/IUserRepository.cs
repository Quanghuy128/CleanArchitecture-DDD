using BuberDinner.Domain.Entities;

namespace BuberDinner.Application.Common.Persistence
{
    public interface IUserRepository
    {
        User? GetUserByEmail(string email);
        void Add(User user);
    }
}
