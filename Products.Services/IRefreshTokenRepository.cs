using Products.Domain;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Products.Services
{
    public interface IRefreshTokenRepository
    {
        Task<RefreshToken> GetUser(string refreshToken);
        Task<RefreshToken> Get(int id);
        Task Add(RefreshToken token);
        Task Delete(int id);
        Task<bool> SaveChanges();

    }
}
