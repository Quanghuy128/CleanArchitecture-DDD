using BuberDinner.Application.Common.Authentication;
using BuberDinner.Application.Common.Persistence;

namespace BuberDinner.Application.Services.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IUserRepository _userRepository;

        public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _userRepository = userRepository;
        }

        public AuthenticationResult Register(string firstName, string lastName, string email, string password)
        {
            //check if user already existed

            //create user (generate unique ID)

            //create Jwt token
            Guid userId = Guid.NewGuid();
            var token = _jwtTokenGenerator.GenerateToken(userId, firstName, lastName);

            return new AuthenticationResult
            (
                userId, 
                firstName, 
                lastName, 
                email, 
                token
            );
        }

        public AuthenticationResult Login(string email, string password)
        {
            return new AuthenticationResult
            (
                Guid.NewGuid(),
                "firstName",
                "lastName",
                email,
                "token"
            );
        }
    }
}
