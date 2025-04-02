using CleanArchWithCQRS.Domain.Repository;
using CleanArchWithCQRS.Infrastructure.Data;
using CleanArchWithCQRS.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchWithCQRS.Infrastructure
{
    public static class ConfigueServices
    {
        public static IServiceCollection AddInfrasructureServices(this IServiceCollection services, IConfiguration configuration)
        {

            //register dbcontext
            services.AddDbContext<BlogDbContext>(options =>
             {
                 options.UseSqlite(configuration.GetConnectionString("BlogDbContext") ?? throw new InvalidOperationException("Connection string 'BlogDbConnection' not found."));
             });

            services.AddTransient<IBlogRepository, BlogRepository>();
            services.AddTransient<IDataSeeder, DataSeeder>();
            return services;
        }
    }
}
