using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Products.Domain;
using Products.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Products.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [EnableCors("AnotherPolicy"), Authorize]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository ProducctRepo;

        public ProductsController(IProductRepository _repo)
        {
            ProducctRepo = _repo;
        }


        // GET: api/Product
        [HttpGet]
        public async Task<IEnumerable<Product>> GetProducts() => await ProducctRepo.GetProducts();


        // GET: api/Product/{id}
        [HttpGet("{id}", Name = "GetProductById")]
        public async Task<ActionResult<Product>> GetProductById(Guid id)
        {
            var product = await ProducctRepo.GetProductById(id);

            if (product != null)
            {
                return Ok(product);
            }
            return NotFound();
        }


        // POST: api/Product
        [HttpPost]
        public async Task<ActionResult> AddProduct([FromBody] Product newProduct)
        {
            if (ModelState.IsValid)
            {

                await ProducctRepo.AddProduct(newProduct);
                await ProducctRepo.SaveChanges();
                return CreatedAtAction(nameof(GetProductById), new { id = newProduct.Id }, newProduct);

            }
            return BadRequest();
        }


        // PUT: api/Product/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult> PutProduct(Guid id, [FromBody] Product product)
        {
            if (id != product.Id)
            {
                return BadRequest();
            }
            var productFrmRepo = await ProducctRepo.GetProductById(id);

            if (productFrmRepo != null)
            {
                productFrmRepo.Name = product.Name;
                productFrmRepo.Description = product.Description;
                productFrmRepo.Category = product.Category;
                productFrmRepo.Price = product.Price;

                ProducctRepo.EditProduct(productFrmRepo);
                await ProducctRepo.SaveChanges();

                return NoContent();
            }

            return NotFound();
        }

        // DELETE: api/Delete/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var product = await ProducctRepo.GetProductById(id);

            if (product != null)
            {
                await ProducctRepo.DeleteProduct(id);
                await ProducctRepo.SaveChanges();

                return NoContent();
            }

            return NotFound();
        }
    }
}
