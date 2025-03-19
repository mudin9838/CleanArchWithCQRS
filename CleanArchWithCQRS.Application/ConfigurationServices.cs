using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace CleanArchWithCQRS.Application
{
    public static class ConfigurationServices
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly()); //add automapper whatever assembly
            services.AddMediatR(ctg => ctg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            return services;
        }
    }
}

