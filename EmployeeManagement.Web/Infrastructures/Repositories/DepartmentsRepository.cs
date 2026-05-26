using Microsoft.EntityFrameworkCore;
using WebApp_Exercise.Applications.Domains;
using WebApp_Exercise.Applications.Repositories;
using WebApp_Exercise.Exceptions;
using WebApp_Exercise.Infrastructures.Adapters;
using WebApp_Exercise.Infrastructures.Context;
namespace WebApp_Exercise.Infrastructures.Repositories;
/// <summary>
/// ドメインオブジェクト:商品のCRUD操作インターフェイスの実装
/// </summary>
public class DepartmentsRepository : IDepartmentsRepository
{
    // DbContext継承クラス
    private readonly AppDbContext _appDbContext;
    // ItemとItemEntityの相互変換
    private readonly DepartmentsEntityAdapter _departmentsAdapter;
   
    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="appDbContext">DbContext継承クラス</param>
    /// <param name="departmentsAdapter">DepartmentsとDepartmentsEntityの相互変換</param>
    /// <param name="stockAdapter">ItemStockとItemStockEntityの相互変換</param>
    public DepartmentsRepository(
        AppDbContext appDbContext, DepartmentsEntityAdapter departmentsAdapter)
    {
        _appDbContext = appDbContext;
        _departmentsAdapter = departmentsAdapter;
    }
    public List<Departments> FindAll()
    {
        var departmentsEntities = _appDbContext.Departments.ToList();
        var departments = departmentsEntities.Select(entity => _departmentsAdapter.Restore(entity)).ToList();
        return departments;
    }


}