using FirstTryDDD.Core.AggregateModels.UserAggregate;
using FirstTryDDD.SharedKernel.Enums; 
using FirstTryDDD.Infrastructure.Data;
using FirstTryDDD.Infrastructure.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FirstTryDDD.Infrastructure.Extensions
{
    public static class ServiceCollectionExtention
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            return services.AddScoped<IUserRepository, UserRepository>(); 
        }

        public static IServiceCollection AddDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            return services.AddDbContext<AppDbContext>(options => configuration.GetConnectionString("FirstTryDDDAPIContext_" + DbMode.Debug));
        }
    }
}
