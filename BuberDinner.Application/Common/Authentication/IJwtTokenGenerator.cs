

using BuberDinner.Domain.Entities;

namespace BuberDinner.Application.Common.Authentication
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(User user);
    }
}
