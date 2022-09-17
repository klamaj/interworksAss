using API.Data;
using Microsoft.EntityFrameworkCore;

namespace API.Extensions;

public static class DbConnectionExtensions
{
    public static IServiceCollection AddDbConnection(this IServiceCollection services, IConfiguration config)
    {
        services.AddDbContext<DatabaseContext>(x => x.UseSqlite(config.GetConnectionString("Connection")));

        return services;
    }
}
