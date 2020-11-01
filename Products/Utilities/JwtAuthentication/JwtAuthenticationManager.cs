using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Products.Domain;
using Products.Models;
using Products.Utilities.JwtAuthentication;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

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
                    Expires = DateTime.UtcNow.AddSeconds(15)
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
            var refreshToken = new RefreshToken();
            var randomNumber = new byte[32];
            using (var randomNumberGenerator = RandomNumberGenerator.Create())
            {
                randomNumberGenerator.GetBytes(randomNumber);
                refreshToken.Token = Convert.ToBase64String(randomNumber);
            }
            refreshToken.Expiry = DateTime.UtcNow.AddDays(30);

            return refreshToken;
        }
    }
}
