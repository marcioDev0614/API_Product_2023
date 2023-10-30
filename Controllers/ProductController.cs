using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Product_API_2023_V1.Data;
using Product_API_2023_V1.Models;

namespace Product_API_2023_V1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductsContext _context;

        public ProductController(ProductsContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("/products")]
        public async Task<ActionResult> GetProducts()
        {
            return Ok(await _context.Products.ToListAsync());
        }

        [HttpPost]
        [Route("/products")]
        public async Task<ActionResult> CreateProduct(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return Ok(product);
        }

        [HttpPut]
        [Route("/products")]
        public async Task<ActionResult> UpdateProducts(Product product)
        {
            var dbProduct = await _context.Products.FindAsync(product.Id);

            if (dbProduct == null)

                return NotFound();

            dbProduct.Name = product.Name;
            dbProduct.Price = product.Price;
            dbProduct.Category = product.Category;

            await _context.SaveChangesAsync();

            return Ok(dbProduct);

        }

        [HttpDelete]
        [Route("/products")]
        public async Task<ActionResult> DeleteProducts(Guid id)
        {
            var dbProduct = await _context.Products.FindAsync(id);

            if (dbProduct == null)

                return NotFound();

            _context.Remove(dbProduct);
            await _context.SaveChangesAsync();

            return NoContent();

        }

    }
}
