using Microsoft.EntityFrameworkCore;
using Products.Domain;
using Products.Domain.AppContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products.Services
{
    public class ApplicationUserRepo : IApplicationUserRepository
    {
        private readonly ProductContext context;

        public ApplicationUserRepo(ProductContext _context)
        {
            context = _context;
        }

        public async Task<IEnumerable<ApplicationUser>> GetAll() => 
            await context.Users.AsNoTracking().ToListAsync();

        public async Task<ApplicationUser> Login(string username, string password)
        {
            var user = await context.Users.AsNoTracking().
                Where(x => x.Username == username && x.Password == password)
                .Include(x=>x.RefreshTokens)
                .FirstOrDefaultAsync();
            return user;
            
        }
        public async Task<ApplicationUser> Get(Guid id)
        {
            return await context.Users.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task Add(ApplicationUser user)
        {
            if (user != null)
            {
                await context.Users.AddAsync(user);
            }
            else
            {
                throw new ArgumentNullException(nameof(user));
            }
        }

        public void Edit(ApplicationUser user)
        {
            //do Nothing Here
            context.Users.Update(user);

        }


        public async Task Delete(Guid id)
        {
            var user = await context.Users.FirstOrDefaultAsync(x => x.Id == id);
            if (user != null)
            {
                context.Users.Remove(user);
            }
        }


        public async Task<bool> SaveChanges() => 
            (await context.SaveChangesAsync() >= 0);
    }
}
