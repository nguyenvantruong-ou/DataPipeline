using DataPipeline.Models;
using Microsoft.EntityFrameworkCore;

namespace DataPipeline.Seeds
{
    public static class AppDbSeeder
    {
        public static async Task SeedAsync(DbAppContext context)
        {
            if (!context.Users.Any())
            {
                var users = new List<User>();
                var countries = new[] { "Vietnam", "USA", "Japan", "Germany", "France", "India", "Brazil", "Canada", "Australia", "UK" };
                for (int i = 1; i <= 10_000; i++)
                {
                    users.Add(new User
                    {
                        FullName = $"User {i}",
                        Email = $"user{i}@mail.com",
                        Age = (20 + i % 30).ToString(),
                        Country = countries[i % countries.Length],
                        City = $"City {i % 100}",
                        CreatedAt = DateTime.UtcNow.ToString("yyyy-MM-dd")
                    });
                }

                await context.Users.AddRangeAsync(users);
                await context.SaveChangesAsync();
            }

            if (!context.Products.Any())
            {
                var products = new List<Product>();
                for (int i = 1; i <= 10_000; i++)
                {
                    products.Add(new Product
                    {
                        ProductName = $"Product {i}",
                        Description = $"Description for product {i}",
                        CreatedAt = DateTime.UtcNow
                    });
                }

                await context.Products.AddRangeAsync(products);
                await context.SaveChangesAsync();
            }

            if (!context.Orders.Any())
            {
                var orders = new List<Order>();
                for (int i = 1; i <= 10_000; i++)
                {
                    orders.Add(new Order
                    {
                        UserId = (i % 10_000) + 1,
                        ProductId = (i % 10_000) + 1,
                        Quantity = (1 + i % 5).ToString(),
                        Price = 100 + i % 50,
                        Static = true,
                        CreatedDate = DateTime.UtcNow
                    });
                }

                await context.Orders.AddRangeAsync(orders);
                await context.SaveChangesAsync();
            }
        }
    }
}
