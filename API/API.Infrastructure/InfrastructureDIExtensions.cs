using API.Domain.Models;
using API.Infrastructure.Db;
using API.Domain.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Infrastructure
{
    public static class InfrastructureDIExtensions
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped<IItemDataService, ItemDataService>();
            services.AddDbContext<ItemDbContext>(options =>
                options.UseInMemoryDatabase("Item"));

            //seed data
            var dbContext = services.BuildServiceProvider().GetService<ItemDbContext>();
            dbContext!.Items.AddRange(
            [
                new Item { Name = "Jeans", Description = "New pair of jeans", Category = "Clothing" },
                new Item { Name = "Maltesers", Description = "A pail of Maltesers", Category = "Food" },
                new Item { Name = "Steam Deck", Description = "Valve Steam Deck", Category = "Electronics" }
            ]);
            dbContext.SaveChanges();

            return services;
        }
    }
}
