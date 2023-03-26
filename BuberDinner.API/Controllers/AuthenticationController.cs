﻿using BuberDinner.Application.Services.Authentication;
using BuberDinner.Contracts.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.API.Controllers
{
    [ApiController]
    [Route("auth")]
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
            AuthenticationResult? authResult = _authenticationService.Register
                (
                    registerRequest.FirstName, 
                    registerRequest.LastName, 
                    registerRequest.Email, 
                    registerRequest.Password
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

        [HttpPost("login")]
        public IActionResult Login(LoginRequest loginRequest)
        {
            AuthenticationResult? authResult = _authenticationService.Login
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
