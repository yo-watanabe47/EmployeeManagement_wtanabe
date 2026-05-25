using Microsoft.EntityFrameworkCore;
using WebApp_Exercise.Applications.Domains;
using WebApp_Exercise.Applications.Repositories;
using WebApp_Exercise.Exceptions;
using WebApp_Exercise.Infrastructures.Adapters;
using WebApp_Exercise.Infrastructures.Context;
namespace WebApp_Exercise.Infrastructures.Repositories;
/// <summary>
/// ドメインオブジェクト:部門のCRUD操作インターフェイスの実装
/// </summary>
public class DeptRepository : IDeptRepository
{
    // DbContext継承クラス
    private readonly AppDbContext _appDbContext;
    // DeptとDeptEntityの相互変換
    private readonly DeptEntityAdapter _deptAdapter;
   
    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="appDbContext">DbContext継承クラス</param>
    /// <param name="itemAdapter">ItemとItemEntityの相互変換</param>
    /// <param name="stockAdapter">ItemStockとItemStockEntityの相互変換</param>
    public DeptRepository(
        AppDbContext appDbContext, DeptEntityAdapter deptAdapter,
        ItemStockEntityAdapter stockAdapter)
    {
        _appDbContext = appDbContext;
        _deptAdapter = deptAdapter;
    }

    /// <summary>
    /// 引数に指定された商品名の存在有無を取得する
    /// </summary>
    /// <param name="name">商品名</param>
    /// <returns>true:存在する false:存在しない</returns>
    /// <exception cref="InternalException">データベースアクセスエラー</exception>
    public bool ExistsByName(string name)
    {
        try
        {
            return _appDbContext.Dept.Any(d => d.Name == name);
        }
        catch (Exception e)
        {
            throw new InternalException("引数に指定された部門名の存在有無を取得できませんでした。", e);
        }
    }



    /// <summary>
    /// 商品を永続化する
    /// </summary>
    /// <param name="item">永続化する商品</param>
    /// <exception cref="InternalException">データベースアクセスエラー</exception>
    public void Create(Dept dept)
    {
        try
        {
            // 1.Deptを永続化する
            var deptEntity = _deptAdapter.Convert(dept);
            _appDbContext.Dept.Add(deptEntity);
            _appDbContext.SaveChanges(); // 部門Id(主キー)が採番される

        
        }
        catch (Exception e)
        {
            throw new InternalException("商品を永続化できませんでした。", e);
        }
    }
}