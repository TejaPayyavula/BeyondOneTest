using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BeyondOne.Data.Models
{
    public static class DataSeeder
    {
        public static async Task<bool> SeedDataAsync(BeyondOne.Data.BeyondOneDbContext dbContext)
        {
            var products = await GetSeedDataAsync();

            await dbContext.AddRangeAsync(products);
            var result = await dbContext.SaveChangesAsync();

            return result > 0;
        }

        public static async Task<IList<Products>> GetSeedDataAsync()
        {
            int[] availableStocks = new int[] { 0, 1, 3, 5, 7, 9 };
            string[] productNames = new string[] { "Coca-Cola Original", "Coca-Cola Lite", "Coca-Cola Zero", "Fritz Cola", "Fritz Lite", "Fritz Zero" };

            return new List<Products>() {
                new Products()
                {
                    ProductId = Guid.NewGuid().ToString("N"),
                    ProductName = productNames[0],
                    AvailableStock = availableStocks[new Random().Next(availableStocks.Length)],
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                },new Products()
                {
                    ProductId = Guid.NewGuid().ToString("N"),
                    ProductName = productNames[1],
                    AvailableStock = availableStocks[new Random().Next(availableStocks.Length)],
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                },new Products()
                {
                    ProductId = Guid.NewGuid().ToString("N"),
                    ProductName = productNames[2],
                    AvailableStock = availableStocks[new Random().Next(availableStocks.Length)],
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                },new Products()
                {
                    ProductId = Guid.NewGuid().ToString("N"),
                    ProductName = productNames[3],
                    AvailableStock = availableStocks[new Random().Next(availableStocks.Length)],
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                },new Products()
                {
                    ProductId = Guid.NewGuid().ToString("N"),
                    ProductName = productNames[4],
                    AvailableStock = availableStocks[new Random().Next(availableStocks.Length)],
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                },new Products()
                {
                    ProductId = Guid.NewGuid().ToString("N"),
                    ProductName = productNames[5],
                    AvailableStock = availableStocks[new Random().Next(availableStocks.Length)],
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                },

            };
        }


    }
}
