using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Products.Domain;
using Products.Models;
using Products.Utilities.JwtAuthentication;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Products.Utilities
{
    public class JwtAuthenticationManager : IJwtAuthenticationManager
    {
        private readonly IConfiguration config;
        public JwtAuthenticationManager(IConfiguration _configuration)
        {
            config = _configuration;
        }

        public string GenerateAccessToken(UserModel user)
        {
            if (user != null)
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var tokenKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Secret_Key"]));
                var credentials = new SigningCredentials(tokenKey, SecurityAlgorithms.HmacSha256Signature);
                var claims = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.UserId.ToString()),
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.Role, user.Role)

                });

                var tokenDescriptor = new SecurityTokenDescriptor()
                {
                    Subject = claims,
                    SigningCredentials = credentials,
                    Issuer = config["Jwt:Issuer"],
                    Audience = config["Jwt:Audience"],
                    IssuedAt = DateTime.UtcNow,
                    Expires = DateTime.UtcNow.AddSeconds(30)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);

                if (token != null)
                {
                    return tokenHandler.WriteToken(token);
                }
            }

            return null;

        }

        public RefreshToken GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using (var randomNumberGenerator = RandomNumberGenerator.Create())
            {
                randomNumberGenerator.GetBytes(randomNumber);

                return new RefreshToken
                {
                    Token = Convert.ToBase64String(randomNumber),
                    //Expires = DateTime.UtcNow.AddDays(30),
                    Expires = DateTime.UtcNow.AddMinutes(10)
                };
            }

        }
    }
}
