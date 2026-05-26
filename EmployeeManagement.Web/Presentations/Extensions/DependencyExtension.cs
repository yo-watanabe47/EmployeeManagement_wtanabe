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
/// <summary>
/// 依存定義および依存性注入クラス
/// </summary>
public static class DependencyExtension
{
    /// <summary>
    /// アプリケーション全体の依存定義を設定する拡張メソッド
    /// </summary>
    /// <param name="services">DIコンテナ</param>
    /// <param name="configuration">アプリケーション環境</param>


    /// <summary>
    /// EntityFramework Coreのインスタンス生成と依存定義
    /// </summary>
    /// <param name="configuration">アプリケーション環境</param>
    /// <param name="services">DIコンテナ</param>
    private static void SettingEntityFrameworkCore(IConfiguration configuration, IServiceCollection services)
    {
        // 接続文字列(appsettings.json)から取得
        var connectionString = configuration.GetConnectionString("PostgreSqlConnection");
        // DbContext登録(PostgreSQL用)
        services.AddDbContext<AppDbContext>(options =>
            options.UseNpgsql(connectionString));
    }



    
}