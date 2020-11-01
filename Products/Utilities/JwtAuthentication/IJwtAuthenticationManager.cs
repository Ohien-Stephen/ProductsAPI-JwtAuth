using Products.Domain;
using Products.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Products.Utilities.JwtAuthentication
{
    public interface IJwtAuthenticationManager
    {
        string GenerateAccessToken(UserModel user);
        RefreshToken GenerateRefreshToken();
    }
}
