using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Infrastructure.Context;

namespace Infrastructure.Configuration;

public static class DbConfigs
{
    public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        switch(configuration.GetSection("ConnectionStrings:ServerODBC").Value?.ToUpper())
        {
            case "SQLITE":
                services.AddDbContext<ApplicationContext>(options =>
                    options.UseSqlite(configuration.GetConnectionString("DefaultConnection")));
                break;
            case "SQLSERVER":
            case "MSSQLSERVER":
            case "MSSQL":
                services.AddDbContext<ApplicationContext>(options =>
                    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
                break;
            case "POSTGRESQL":
            case "POSTGRES":
                services.AddDbContext<ApplicationContext>(options =>
                    options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));
                break;
            case "MYSQL":
                services.AddDbContext<ApplicationContext>(options =>
                    options.UseMySQL(configuration.GetConnectionString("DefaultConnection")));
                break;
            default:
                services.AddDbContext<ApplicationContext>(options =>
                    options.UseSqlite(configuration.GetConnectionString("DefaultConnection")));
                break;
        }

        return services;
    }
}