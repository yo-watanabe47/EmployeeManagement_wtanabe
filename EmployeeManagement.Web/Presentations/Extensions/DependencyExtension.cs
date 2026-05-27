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
    public static void SettingDependencyInjection(
        this IServiceCollection services, IConfiguration configuration)
    {
        SettingEntityFrameworkCore(configuration, services);
        SettingInfrastructures(services);
        SettingApplications(services);
        SettingPresentations(services);
    }
    
    
    private static void SettingEntityFrameworkCore(IConfiguration configuration, IServiceCollection services)
    {
        var connectionString = configuration.GetConnectionString("PostgreSqlConnection");
        services.AddDbContext<AppDbContext>(options =>
            options.UseNpgsql(connectionString));
    }
    
    
    private static void SettingPresentations(IServiceCollection services)
    {
        services.AddScoped<DepartmentsViewModelAdapter>();
        services.AddScoped<EmployeesViewModelAdapter>();
    }


    private static void SettingInfrastructures(IServiceCollection services)
    {
        services.AddScoped<IDepartmentsRepository, DepartmentsRepository>();
        services.AddScoped<DepartmentsEntityAdapter>();

        services.AddScoped<IEmployeesRepository, EmployeesRepository>();
        services.AddScoped<EmployeesEntityAdapter>();
    }


    private static void SettingApplications(IServiceCollection services)
    {
        services.AddScoped<IDepartmentsService, DepartmentsService>();
        services.AddScoped<IEmployeesService, EmployeesService>();
    }
}