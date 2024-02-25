using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MyAdsApi.Models;

namespace MyAdsApi.Data
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>());

            // Check if there is already existing data
            if (context.Users.Any())
            {
                // Data already seeded, no need to continue
                return;
            }

            // Seed initial data
            var users = new User[]
            {
                new User { Username = "admin", Email = "admin@example.com", Password = "admin123", Coins = 1000 },
                new User { Username = "moderator", Email = "moderator@example.com", Password = "moderator123", Coins = 500 }
            };

            context.Users.AddRange(users);
            context.SaveChanges();
        }
    }
}
