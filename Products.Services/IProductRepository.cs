using Products.Domain;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Products.Services
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetProducts();
        Task<Product> GetProductById(Guid id);
        void EditProduct(Product product);
        Task AddProduct(Product product);
        Task DeleteProduct(Guid id);
        Task<bool> SaveChanges();

    }
}
