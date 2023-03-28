using BuberDinner.Application.Services.Authentication;
using BuberDinner.Contracts.Authentication;
using Microsoft.AspNetCore.Mvc;
using ErrorOr;

namespace BuberDinner.API.Controllers
{
    [ApiController]
    [Route("auth")]
    //[ErrorHandlingFilterAttribute]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost("register")]
        public IActionResult Register(RegisterRequest registerRequest)
        {
            ErrorOr<AuthenticationResult> authResult = _authenticationService.Register
                (
                    registerRequest.FirstName, 
                    registerRequest.LastName, 
                    registerRequest.Email, 
                    registerRequest.Password
                );
            return authResult.MatchFirst(
                    authResult => Ok(MapAuthResult(authResult)),
                    firstError => Problem(statusCode: StatusCodes.Status409Conflict, title: firstError.Description)
                );
            
        }

        private static AuthenticationResponse MapAuthResult(AuthenticationResult authResult)
        {
            return new AuthenticationResponse
                (
                    authResult.User.Id,
                    authResult.User.FirstName,
                    authResult.User.LastName,
                    authResult.User.Email,
                    authResult.Token
                );
        }

        [HttpPost("login")]
        public IActionResult Login(LoginRequest loginRequest)
        {
            ErrorOr<AuthenticationResult> authResult = _authenticationService.Login
            (
                loginRequest.Email,
                loginRequest.Password
            );

            AuthenticationResponse? authResponse = new AuthenticationResponse
                (
                    authResult.User.Id,
                    authResult.User.FirstName,
                    authResult.User.LastName,
                    authResult.User.Email,
                    authResult.Token
                );
            return Ok(authResponse);
        }
    }
}
