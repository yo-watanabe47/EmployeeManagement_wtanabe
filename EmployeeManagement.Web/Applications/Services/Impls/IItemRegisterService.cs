using WebApp_Exercise.Applications.Domains;
using WebApp_Exercise.Applications.Repositories;
using WebApp_Exercise.Exceptions;
using WebApp_Exercise.Infrastructures.Context;
namespace WebApp_Exercise.Applications.Services.Impls;
/// <summary>
/// 商品登録サービスインターフェイスの実装
/// </summary>
public class ItemRegisterService : IItemRegisterService
{
    // アプリケーションで利用するDbContext継承
    private readonly AppDbContext _context;
    // 商品のCRUD操作インターフェイス
    private readonly IItemRepository _itemRepository;
    // 商品カテゴリのCRUD操作インターフェイス
    private readonly IItemCategoryRepository _itemCategoryRepository;
    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="context">アプリケーションで利用するDbContext継承</param>
    /// <param name="itemRepository">商品のCRUD操作インターフェイス</param>
    /// <param name="itemCategoryRepository">商品カテゴリのCRUD操作インターフェイス</param>
    public ItemRegisterService(
        AppDbContext context,
        IItemRepository itemRepository,
        IItemCategoryRepository itemCategoryRepository)
    {
        _context = context;
        _itemRepository = itemRepository;
        _itemCategoryRepository = itemCategoryRepository;
    }

    /// <summary>
    /// 引数に指定された商品名の有無を調べる
    /// </summary>
    /// <param name="name">商品名</param>
    /// <exception cref="ExistsExceotioin">存在する場合にスローする例外</exception>
    public void Exists(string name)
    {
        var exists = _itemRepository.ExistsByName(name);
        if (exists)
        {
            throw new ExistsException($"商品名:{name}は既に存在します。");
        }
    }

    /// <summary>
    /// 商品カテゴリの一覧を取得する
    /// </summary>
    /// <returns>商品カテゴリリスト</returns>
    public List<ItemCategory> GetItemCategories()
    {
        return _itemCategoryRepository.FindAll();
    }

    /// <summary>
    /// 指定されたIdの商品カテゴリを取得する
    /// </summary>
    /// <param name="id">商品カテゴリ   Id</param>
    /// <returns>該当する商品カテゴリ</returns>
    /// <exception cref="NotFoundExceotioin">存在しない場合にスローする例外</exception>
    public ItemCategory GetItemCategoryById(int id)
    {
        var result = _itemCategoryRepository.FindById(id);
        if (result == null)
        {
            throw new NotFoundException($"指定されたId:{id}の商品カテゴリは存在しません。");
        }
        return result;
    }

    /// <summary>
    /// 商品と在庫を永続化する
    /// </summary>
    /// <param name="item">永続化する商品</param>
    public void Register(Item item)
    {
        try
        {
            _context.Database.BeginTransaction();
            _itemRepository.Create(item);
            _context.Database.CommitTransaction();
            
        }catch 
        {
            _context.Database.RollbackTransaction();
            throw;
        }
    }
}