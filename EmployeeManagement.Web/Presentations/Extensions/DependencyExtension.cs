using Microsoft.EntityFrameworkCore;
using WebApp_Exercise.Applications.Repositories;
using WebApp_Exercise.Applications.Services;
using WebApp_Exercise.Applications.Services.Impls;
using WebApp_Exercise.Infrastructures.Adapters;
using WebApp_Exercise.Infrastructures.Context;
using WebApp_Exercise.Infrastructures.Repositories;
using WebApp_Exercise.Presentations.Controllers;
using WebApp_Exercise.Presentations.ViewModels;
namespace WebApp_Exercise.Presentations.Extensions;

public static class DependencyExtension
{
    public static IServiceCollection SettingDependencyInjection(this IServiceCollection services, IConfiguration configuration)
    {
        SettingEntityFrameworkCore(configuration, services);

        services.AddScoped<IDepartmentsService, DepartmentsService>();
        services.AddScoped<IDepartmentsRepository, DepartmentsRepository>();
        services.AddScoped<DepartmentsEntityAdapter>();
        return services;
    }

    private static void SettingEntityFrameworkCore(IConfiguration configuration, IServiceCollection services)
    {
        var connectionString = configuration.GetConnectionString("PostgreSqlConnection");
        services.AddDbContext<AppDbContext>(options =>
            options.UseNpgsql(connectionString));
    }
}