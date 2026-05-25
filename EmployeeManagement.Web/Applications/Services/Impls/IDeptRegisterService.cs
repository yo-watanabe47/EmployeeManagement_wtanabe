using WebApp_Exercise.Applications.Domains;
using WebApp_Exercise.Applications.Repositories;
using WebApp_Exercise.Exceptions;
using WebApp_Exercise.Infrastructures.Context;
namespace WebApp_Exercise.Applications.Services.Impls;
/// <summary>
/// 部門登録サービスインターフェイスの実装
/// </summary>
public class DeptRegisterService : IDeptRegisterService
{
    // アプリケーションで利用するDbContext継承
    private readonly AppDbContext _context;
    // 部門のCRUD操作インターフェイス
    private readonly IDeptRepository _deptRepository;
    // 商品カテゴリのCRUD操作インターフェイス
    private readonly IItemCategoryRepository _itemCategoryRepository;
    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="context">アプリケーションで利用するDbContext継承</param>
    /// <param name="deptRepository">部門のCRUD操作インターフェイス</param>
    /// <param name="itemCategoryRepository">商品カテゴリのCRUD操作インターフェイス</param>
    public DeptRegisterService(
        AppDbContext context,
        IDeptRepository deptRepository,
        IItemCategoryRepository itemCategoryRepository)
    {
        _context = context;
        _deptRepository = deptRepository;
        _itemCategoryRepository = itemCategoryRepository;
    }

    /// <summary>
    /// 引数に指定された部門名の有無を調べる
    /// </summary>
    /// <param name="name">部門名</param>
    /// <exception cref="ExistsExceotioin">存在する場合にスローする例外</exception>
    public void Exists(string name)
    {
        var exists = _deptRepository.ExistsByName(name);
        if (exists)
        {
            throw new ExistsException($"部門名:{name}は既に存在します。");
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
    /// 部門を永続化する
    /// </summary>
    /// <param name="dept">永続化する部門</param>
    public void Register(Dept dept)
    {
        try
        {
            _context.Database.BeginTransaction();
            _deptRepository.Create(dept);
            _context.Database.CommitTransaction();
            
        }catch 
        {
            _context.Database.RollbackTransaction();
            throw;
        }
    }
}