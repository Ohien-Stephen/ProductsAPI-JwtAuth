using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Products.Domain;
using Products.Models;
using Products.Services;
using Products.Utilities;
using Products.Utilities.JwtAuthentication;

namespace Products.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IJwtAuthenticationManager jwtAuthenticationManager;
        private readonly IApplicationUserRepository applicationUserRepository;
        private readonly IRefreshTokenRepository refreshTokenRepository;

        public LoginController(IJwtAuthenticationManager _jwtAuthenticationManager,
            IApplicationUserRepository _applicationUserRepository,
            IRefreshTokenRepository _refreshTokenRepository)
        {
            jwtAuthenticationManager = _jwtAuthenticationManager;
            applicationUserRepository = _applicationUserRepository;
            refreshTokenRepository = _refreshTokenRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginModel login)
        {
            var user = await applicationUserRepository.Login(login.Username, login.Password);
            if (user == null)
            {
                return Unauthorized("Invalid Username and Password");
            }
            var userModel = new UserModel()
            {
                UserId = user.Id,
                Username = user.Username,
                Email = user.Email,
                Role = user.Role
            };
            var refreshToken = jwtAuthenticationManager.GenerateRefreshToken();

            user.RefreshTokens.Add(refreshToken);
            await refreshTokenRepository.SaveChanges();

            var response = new AuthenticationModel()
            {
                AccessToken = jwtAuthenticationManager.GenerateAccessToken(userModel),
                RefreshToken = refreshToken.Token,
                User = userModel
            };

            if (response != null)
            {
                return Ok(response);
            }
            return Unauthorized();

        }

        [HttpPost("/RefreshToken")]
        public async Task<IActionResult> RefreshToken(string accessToken, string refreshToken)
        {
            return Unauthorized();

        }

        [Authorize]
        [HttpPost("/Logout")]
        public async Task<IActionResult> Logout()
        {
            return Ok("Log Out Succesfull");
        }
    }
}