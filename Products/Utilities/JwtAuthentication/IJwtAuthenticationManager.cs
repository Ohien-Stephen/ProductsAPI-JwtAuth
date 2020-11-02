using Products.Domain;
using Products.Models;

namespace Products.Utilities.JwtAuthentication
{
    public interface IJwtAuthenticationManager
    {
        string GenerateAccessToken(UserModel user);
        RefreshToken GenerateRefreshToken();
    }
}
