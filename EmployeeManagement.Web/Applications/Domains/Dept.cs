using WebApp_Exercise.Exceptions;
namespace WebApp_Exercise.Applications.Domains;
/// <summary>
/// 商品を表すドメインオブジェクト
/// </summary>
public class Dept 
{
    /// <summary>
    /// 商品Id
    /// </summary>
    public int? Id { get; private set; }      
    /// <summary>
    /// 商品名
    /// </summary>
    public string? Name { get; private set; } = string.Empty;    
    
    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="id">商品Id</param>
    /// <param name="name">商品名</param>
    /// <param name="price">単価</param>
    public Dept(int? id , string? name , int? price)
    {
        ValidateId(id);
        ValidateName(name);
        Id = id;
        Name = name;
    }

    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="name">商品名</param>
    /// <param name="price">単価</param>
    public Dept(string? name , int? price) :this (null , name , price) {}

    public Dept(string? name)
    {
        Name = name;
    }

    public Dept(int? id, string? name)
    {
        Id = id;
        Name = name;
    }

    /// <summary>
    /// 商品Idのルール検証
    /// </summary>
    /// <param name="id"></param>
    private void ValidateId(int? id)
    {
        if (id == null)
        {
            return;
        }
        if (id < 1)
        {
            throw new DomainException("商品Idは1以上でなければなりません。");
        }
    }

    /// <summary>
    /// 商品名のルール検証
    /// </summary>
    private void ValidateName(string? name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new DomainException("商品名は必須です。");
        if (name.Length > 30)
            throw new DomainException("商品名は30文字以内で指定してください。");
    }


    /// <summary>
    /// 商品名の変更
    /// </summary>
    public void ChangeName(string? name)
    {
        ValidateName(name);
        Name = name;
    }

    /// <summary>
    /// 等価性の検証（Idが一致していれば同一とみなす）
    /// </summary>
    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(this, obj)) return true;
        if (obj is not Dept other) return false;
        return Id == other.Id;
    }

    public override int GetHashCode() => Id?.GetHashCode() ?? 0;

    public override string ToString()
    {
        var idText = Id?.ToString() ?? "未登録";
        var nameText = string.IsNullOrWhiteSpace(Name) ? "未登録" : Name;
        return $"部門Id={idText},部門名={nameText}";
    }   
}