using BuberDinner.Contracts.Authentication;
using Microsoft.AspNetCore.Mvc;
using BuberDinner.Domain.Common.Errors;
using ErrorOr;
using BuberDinner.Application.Services.Authentication.Commands;
using BuberDinner.Application.Services.Authentication.Common;
using BuberDinner.Application.Services.Authentication.Queries;

namespace BuberDinner.API.Controllers
{
    //[ApiController]
    [Route("auth")]
    //[ErrorHandlingFilterAttribute]
    public class AuthenticationController : ApiController
    {
        private readonly IAuthenticationCommandService _authenticationCommandService;

        private readonly IAuthenticationQueryService _authenticationQueryService;

        public AuthenticationController(IAuthenticationCommandService authenticationService, IAuthenticationQueryService authenticationQueryService)
        {
            _authenticationCommandService = authenticationService;
            _authenticationQueryService = authenticationQueryService;
        }

        [HttpPost("register")]
        public IActionResult Register(RegisterRequest registerRequest)
        {
            ErrorOr<AuthenticationResult> authResult = _authenticationCommandService.Register
                (
                    registerRequest.FirstName, 
                    registerRequest.LastName, 
                    registerRequest.Email, 
                    registerRequest.Password
                );
            return authResult.Match(
                    authResult => Ok(MapAuthResult(authResult)),
                    errors => Problem(errors)
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
            ErrorOr<AuthenticationResult> authResult = _authenticationQueryService.Login
            (
                loginRequest.Email,
                loginRequest.Password
            );

            if(authResult.IsError && authResult.FirstError == Errors.Authentication.InvalidCredentials)
            {
                return Problem(
                    statusCode: StatusCodes.Status401Unauthorized, 
                    title: authResult.FirstError.Description
                );
            }

            return authResult.Match(
                    authResult => Ok(MapAuthResult(authResult)),
                    errors => Problem(errors)
                );
        }
    }
}
