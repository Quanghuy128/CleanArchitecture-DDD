using System;
using System.Collections.Generic;

namespace BuberDinner.Application.Common.Authentication
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(Guid userId, string firstName, string lastName);
    }
}
