using WebApp_Exercise.Exceptions;
namespace WebApp_Exercise.Applications.Domains;
/// <summary>
/// 商品カテゴリを表すドメインオブジェクト
/// </summary>
public class ItemCategory 
{
    /// <summary>
    /// 商品カテゴリId
    /// </summary>
    public int? Id { get; private set; }
    /// <summary>
    /// 商品カテゴリ名
    /// </summary>
    public string? Name { get; private set; } = string.Empty;

    /// <summary>
    /// コンストラクタ
    /// </summary>
    public ItemCategory(int? id, string? name)
    {   
        // 商品カテゴリIdのルール検証
        ValidateId(id);
        // 商品カテゴリ名のルール検証
        ValidateName(name);
        Id = id;
        Name = name;
    }
    /// <summary>
    /// コンストラクタ
    /// </summary>
    public ItemCategory(string? name) : this(null , name) {}

    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="id"></param>
    public ItemCategory(int? id) : this(id , null) {}
    
    /// <summary>
    /// 商品カテゴリIdのルール検証
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
            throw new DomainException("商品カテゴリIdは1以上でなければなりません。");
        }
    }

    /// <summary>
    /// 商品カテゴリ名のルール検証
    /// </summary>
    /// <param name="name"></param>
    private void ValidateName(string? name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new DomainException("商品カテゴリ名は必須です。");
        }      
        if (name.Length > 20)
        {
            throw new DomainException("商品カテゴリ名は20文字以内で指定してください。");
        }
    }

    /// <summary>
    /// 商品カテゴリ名の変更
    /// </summary>
    /// <param name="name"></param>
    public void ChangeName(string? name)
    {
        // 商品カテゴリ名のルール検証
        ValidateName(name);
        this.Name = name;
    }

    /// <summary>
    /// 等価性の検証
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(this, obj)) return true;
        if (obj is not ItemCategory other) return false;
        return Id == other.Id;
    }
    public override int GetHashCode() => Id?.GetHashCode() ?? 0;

    public override string ToString()
    {
        var idText = Id?.ToString() ?? "未登録";
        var nameText = string.IsNullOrWhiteSpace(Name) ? "未登録" : Name;
        return $"商品カテゴリId={idText},商品カテゴリ名{nameText}"; 
    }
}