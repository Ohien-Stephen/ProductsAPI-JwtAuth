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
        Task<RefreshToken> Get(string id);
        Task Add(RefreshToken token);
        Task Delete(string id);
        Task<bool> SaveChanges();

    }
}
