using BuberDinner.Application.Common.Authentication;
using BuberDinner.Application.Common.Persistence;
using BuberDinner.Domain.Entities;

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
            //1. Validate user doesn't exist
            if(_userRepository.GetUserByEmail(email) is not null)
            {
                throw new Exception("User with provided email already exists.");
            }

            //2. Create user (generate unique ID) & persist to Db
            var user = new User{
                FirstName= firstName,
                LastName= lastName,
                Email= email,
                Password= password
            };

            _userRepository.Add(user);

            //3. Create Jwt token
            var token = _jwtTokenGenerator.GenerateToken(user);

            return new AuthenticationResult
            (
                user,
                token
            );
        }

        public AuthenticationResult Login(string email, string password)
        {
            //1. Validate user exists
            if(_userRepository.GetUserByEmail(email) is not User user)
            {
                throw new Exception("User with provided email does not exist!");
            }
            //2. Validate password is correct
            if(user.Password != password)
            {
                throw new Exception("Invalid Password!");
            }
            //3. Creat JWT
            var token = _jwtTokenGenerator.GenerateToken(user);
            return new AuthenticationResult
            (
                user,
                token
            );
        }
    }
}
