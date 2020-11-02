using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Products.Domain;
using Products.Models;
using Products.Services;
using Products.Utilities.JwtAuthentication;
using System;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IJwtAuthenticationManager jwtAuthenticationManager;
        private readonly IApplicationUserRepository applicationUserRepository;
        private readonly IRefreshTokenRepository refreshTokenRepository;
        private readonly IConfiguration configuration;

        public LoginController(IJwtAuthenticationManager _jwtAuthenticationManager,
            IApplicationUserRepository _applicationUserRepository,
            IRefreshTokenRepository _refreshTokenRepository,
            IConfiguration _configuration)
        {
            jwtAuthenticationManager = _jwtAuthenticationManager;
            applicationUserRepository = _applicationUserRepository;
            refreshTokenRepository = _refreshTokenRepository;
            configuration = _configuration;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginModel login)
        {
            var user = await applicationUserRepository.Login(login.Username, login.Password);

            if (user != null)
            {
                var response = new AuthenticationModel();
                var userModel = new UserModel()
                {
                    UserId = user.Id,
                    Username = user.Username,
                    Email = user.Email,
                    Role = user.Role
                };
                response.User = userModel;

                response.AccessToken = jwtAuthenticationManager.GenerateAccessToken(userModel);


                if (user.RefreshTokens.Any(x => x.isExpired == false))
                {
                    var activeRefreshToken = user.RefreshTokens
                        .Where(x => x.isExpired == false).FirstOrDefault();
                    response.RefreshToken = activeRefreshToken.Token;
                }
                else
                {
                    var newRefreshToken = jwtAuthenticationManager.GenerateRefreshToken();

                    newRefreshToken.ApplicationUserId = user.Id;
                    await refreshTokenRepository.Add(newRefreshToken);
                    await refreshTokenRepository.SaveChanges();

                    response.RefreshToken = newRefreshToken.Token;
                }
                if (response != null)
                {
                    return Ok(response);
                }
            }

            return Unauthorized("Invalid Username and Password");


        }

        [HttpPost("/RefreshToken")]
        public async Task<IActionResult> RefreshToken([FromBody] RefreshModel token)
        {
            var refreshToken = await refreshTokenRepository.Get(token.RefreshToken);

            if (refreshToken != null && refreshToken.ApplicationUser != null)
            {
                if (refreshToken.isExpired)
                {
                    return Unauthorized("Please Login");

                    //var newRefreshToken = jwtAuthenticationManager.GenerateRefreshToken();
                    //newRefreshToken.ApplicationUserId = userModel.UserId;
                    //await refreshTokenRepository.Add(newRefreshToken);
                    //await refreshTokenRepository.SaveChanges();
                    //response.RefreshToken = newRefreshToken.Token;
                }

                var userModel = new UserModel()
                {
                    UserId = refreshToken.ApplicationUser.Id,
                    Username = refreshToken.ApplicationUser.Username,
                    Email = refreshToken.ApplicationUser.Email,
                    Role = refreshToken.ApplicationUser.Role
                };

                var response = new AuthenticationModel
                {
                    User = userModel,
                    AccessToken = jwtAuthenticationManager.GenerateAccessToken(userModel),
                    RefreshToken = token.RefreshToken
                };

                if (response != null)
                {
                    return Ok(response);
                }
            }

            return Unauthorized("Please Login");

        }

        private ApplicationUser GetUserFromAccessToken(string accessToken)
        {
            //var tokenHandler = new JwtSecurityTokenHandler();
            //if (tokenHandler.CanReadToken(accessToken))
            //{
            //    var tokenKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(configuration["Jwt:Secret_Key"]));
            //    var tokenValidationParameters = new TokenValidationParameters()
            //    {
            //        ValidateIssuerSigningKey = true,
            //        IssuerSigningKey = tokenKey,
            //        ValidateIssuer = false,
            //        ValidateAudience = false,
            //        ValidIssuer = configuration["Jwt:Issuer"],
            //        ValidAudience = configuration["Jwt:Audience"],
            //        ClockSkew = TimeSpan.Zero
            //    };

            //    try
            //    {
            //        var principal = tokenHandler.ValidateToken(
            //        accessToken,
            //        tokenValidationParameters,
            //        out SecurityToken securityToken
            //        ).Clone();

            //        JwtSecurityToken jwtSecurityToken = securityToken as JwtSecurityToken;

            //        if (jwtSecurityToken != null && jwtSecurityToken.Header.Alg.
            //            Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
            //        {
            //            var userId = principal.Identity.Name;
            //            return applicationUserRepository.Get(Guid.Parse(userId)).GetAwaiter().GetResult();
            //        }
            //    }
            //    catch (Exception ex)
            //    {

            //        Debug.WriteLine(ex.Message);
            //    }
            //}


            return null;
        }

        [Authorize]
        [HttpPost("/Logout")]
        public async Task<IActionResult> Logout()
        {

            return Ok(new { User.Identity });
        }
    }
}