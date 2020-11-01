using Products.Domain;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Products.Services
{
    public interface IApplicationUserRepository
    {
        Task<IEnumerable<ApplicationUser>> GetAll();
        Task<ApplicationUser> Login(string username, string password);
        Task<ApplicationUser> Get(Guid id);
        void Edit(ApplicationUser user);
        Task Add(ApplicationUser user);
        Task Delete(Guid id);
        Task<bool> SaveChanges();

    }
}
