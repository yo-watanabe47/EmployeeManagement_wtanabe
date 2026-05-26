using Microsoft.EntityFrameworkCore;
using WebApp_Exercise.Infrastructures.Entities;
namespace WebApp_Exercise.Infrastructures.Context;
/// <summary>
/// アプリケーションで利用するDbContext継承クラス
/// </summary>
public class AppDbContext : DbContext
{
    public DbSet<DepartmentsEntity> Departments { get; set; } = null!;
        public DbSet<EmployeesEntity> Employees { get; set; } = null!;
        public DbSet<LoginEntity> Logins { get; set; } = null!;
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}