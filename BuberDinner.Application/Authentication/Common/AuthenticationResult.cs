using BuberDinner.Domain.UserAggrerate.Entities;

namespace BuberDinner.Application.Authentication.Common
{
    public record AuthenticationResult
    (
        User User,
        string Token
    );
}
