using Microsoft.EntityFrameworkCore;
using Products.Domain;
using Products.Domain.AppContext;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Products.Services
{
    public class ProductRepo : IProductRepository
    {
        private readonly ProductContext context;

        public ProductRepo(ProductContext _context)
        {
            context = _context;
        }

        public async Task<IEnumerable<Product>> GetProducts() => await context.Products.AsNoTracking().ToListAsync();


        public async Task<Product> GetProductById(Guid id)
        {
            return await context.Products.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task AddProduct(Product product)
        {
            if (product != null)
            {
                await context.Products.AddAsync(product);
            }
            else
            {
                throw new ArgumentNullException(nameof(product));
            }
        }

        public void EditProduct(Product product)
        {
            //do Nothing Here
            context.Products.Update(product);

        }


        public async Task DeleteProduct(Guid id)
        {
            var product = await context.Products.FirstOrDefaultAsync(x => x.Id == id);
            if (product != null)
            {
                context.Products.Remove(product);
            }
        }


        public async Task<bool> SaveChanges() => (await context.SaveChangesAsync() >= 0);
    }
}
