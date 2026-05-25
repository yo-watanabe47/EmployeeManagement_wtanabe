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
    public static void SettingDependencyInjection(
        this IServiceCollection services, IConfiguration configuration)
    {
        // EntityFramework Coreのインスタンス生成と依存定義
        SettingEntityFrameworkCore(configuration, services);
        // インフラストラクチャ層のインスタンス生成と依存定義
        SettingInfrastructures(services);
        // アプリケーション層のインスタンス生成と依存定義
        SettingApplications(services);
        // プレゼンテーション層のインスタンス生成と依存定義
        SettingPresentations(services);
    }

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

    /// <summary>
    /// インフラストラクチャ層のインスタンス生成と依存定義
    /// </summary>
    /// <param name="services">DIコンテナ</param>
    private static void SettingInfrastructures(IServiceCollection services)
    {
        // ドメインモデル:商品カテゴリと商品カテゴリエンティティの相互変換インターフェイスの実装
        services.AddScoped<ItemCategoryEntityAdapter>();
        // ドメインモデル:商品と商品エンティティの相互変換インターフェイスの実装
        services.AddScoped<ItemEntityAdapter>();
        // ドメインモデル:商品在庫と商品在庫エンティティの相互変換インターフェイスの実装
        services.AddScoped<ItemStockEntityAdapter>();
        // ドメインオブジェクト:商品カテゴリのCRUD操作インターフェイス実装
        services.AddScoped<IItemCategoryRepository, ItemCategoryRepository>();
        // ドメインオブジェクト:商品のCRUD操作インターフェイスの実装
        services.AddScoped<IItemRepository, ItemRepository>();
    }

    /// <summary>
    /// アプリケーション層のインスタンス生成と依存定義
    /// </summary>
    /// <param name="services">DIコンテナ</param>
    private static void SettingApplications(IServiceCollection services)
    {
        // 商品登録サービスインターフェイスの実装
        services.AddScoped<IItemRegisterService, ItemRegisterService>();
    }


    /// <summary>
    /// プレゼンテーション層のインスタンス生成と依存定義
    /// </summary>
    /// <param name="services">DIコンテナ</param>
    private static void SettingPresentations(IServiceCollection services)
    {
        // 商品登録ViewModelをドメインオブジェクト:商品に変換するアダプターインターフェイスの実装
        services.AddScoped<ItemRegisterViewModelAdapter>();
        // TempDataへのItemRegisterViewの保存・復元するためのクラス
        // コンストラクタを利用して明示的にDIコンテナにインスタンスを登録する
        services.AddScoped(
            provider =>
            new TempDataStore<ItemRegisterViewModel>("ItemRegisterViewModel")
        );
    }       
}