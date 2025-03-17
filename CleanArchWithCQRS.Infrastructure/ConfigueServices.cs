using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchWithCQRS.Infrastructure
{
    public static class ConfigueServices
    {
        public static IServiceCollection AddInfrasructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            return services;
        }
    }
}
