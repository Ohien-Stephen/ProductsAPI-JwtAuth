using Microsoft.EntityFrameworkCore;
using Products.Domain;
using Products.Domain.AppContext;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace Products.Services
{
    public class RefreshTokenRepo : IRefreshTokenRepository
    {
        private readonly ProductContext context;

        public RefreshTokenRepo(ProductContext _context)
        {
            context = _context;
        }

        public async Task<RefreshToken> Get(int id)
        {
            return await context.RefreshTokens.AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<RefreshToken> GetUser(string refreshToken)
        {
            var user = await context.RefreshTokens.Include(x => x.ApplicationUser)
                .FirstOrDefaultAsync(x => x.Token == refreshToken);
            return user;

        }
        public async Task Add(RefreshToken token)
        {
            if (token != null)
            {
                await context.RefreshTokens.AddAsync(token);
            }
        }


        public async Task Delete(int id)
        {
            var token = await context.RefreshTokens.FirstOrDefaultAsync(x => x.Id == id);
            if (token != null)
            {
                context.RefreshTokens.Remove(token);
            }
        }


        public async Task<bool> SaveChanges() => (await context.SaveChangesAsync() >= 0);

    }
}
