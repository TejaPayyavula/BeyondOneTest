using BeyondOne.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using BeyondOne.Data;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BeyondOneChallenge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class ProductsController : ControllerBase
    {
        private readonly BeyondOneDbContext _db;
        public ProductsController(BeyondOneDbContext db)
        {
            this._db = db;
        }

        // GET: api/Products
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            IList<Products> products;
            try
            {
                products = await _db.Products.Select(s => new Products()
                {
                    Id = s.Id,
                    ProductId = s.ProductId,
                    ProductName = s.ProductName,
                    CreatedAt = s.CreatedAt,
                    DeletedAt = s.DeletedAt
                }).OrderBy(x => x.Id).ToListAsync();
            }
            catch (Exception ex)
            {
                while (ex.InnerException != null)
                    ex = ex.InnerException;
                throw;
            }
            return Ok(products);
        }

        // DELETE api/Products/5
        [HttpPost("{id}")]
        public async Task<IActionResult> VerifyStock(int? id)
        {
            string result;
            try
            {
                if (!id.HasValue)
                    throw new ArgumentNullException(nameof(Products.Id));

                var product = await _db.Products.FirstOrDefaultAsync(x => x.Id == id);

                if (product == null)
                    throw new Exception("Product not found!");

                if (product.AvailableStock == 0)
                    result = "Stock not available or Out of stock";

                result = $"{product.AvailableStock} products available";

            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);

                throw;
            }
            return new JsonResult(result);
        }

        // GET /api/Products/seed
        [AllowAnonymous]
        [HttpGet("[action]")]
        public async Task<IActionResult> Seed()
        {
            object? result = null;
            try
            {
                result = await DataSeeder.SeedDataAsync(_db);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);
                throw;
            }
            return new JsonResult(result);
        }
    }
}
