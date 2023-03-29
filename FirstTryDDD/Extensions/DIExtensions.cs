using FirstTryDDD.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections;

namespace FirstTryDDD.API.Extensions
{
    public static class DIExtensions
    {
        public static IServiceCollection AddDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            return services.AddDbContext<AppDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("AppDbContext")));
        }

        public static IServiceCollection AddBussinessServices(this IServiceCollection services)
        {
            return services; 
        }

    }
}
