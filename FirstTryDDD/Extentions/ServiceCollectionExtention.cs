using FirstTryDDD.Core.AggregateModels.UserAggregate;
using FirstTryDDD.SharedKernel.Enums;
using FirstTryDDD.Infrastructure.Data;
using FirstTryDDD.Infrastructure.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using FirstTryDDD.API.Services;

namespace FirstTryDDD.API.Extentions
{
    public static class ServiceCollectionExtention
    {
        public static IServiceCollection AddDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            return services.AddDbContext<AppDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("FirstTryDDDAPIContext_" + DbMode.Debug)));
        }
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            return services.AddScoped<IUserRepository, UserRepository>();
        }
        public static IServiceCollection AddBusinessServices(this IServiceCollection services )
        {
            return services.AddScoped<UserServices>();
        }
    }
}
