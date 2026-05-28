using WebApp_Exercise.Exceptions;
namespace WebApp_Exercise.Applications.Domains;
/// <summary>
/// 商品を表すドメインオブジェクト
/// </summary>
public class Departments 
{

    public int? Id { get; private set; }      

    public string? Dept_name { get; init; } = string.Empty;    

    public DateTime? Created_at { get; init; } = DateTime.Now;

    public string? Created_emp_no { get; init; } = string.Empty;

    public DateTime? Updated_at { get; init; } = DateTime.Now;
    
    public string? Updated_emp_no { get; init; } = null;

    public Departments(
        int? id ,
        string? dept_name ,
        DateTime? created_at,
        string? created_emp_no,
        DateTime? updated_at,
        string? updated_emp_no)
    {
        ValidateId(id);
        ValidateDeptName(dept_name);
        ValidateCreatedEmpNo(created_emp_no);
        Id = id;
        Dept_name = dept_name;
        Created_at = created_at;
        Created_emp_no = created_emp_no;
        Updated_at = updated_at;
        Updated_emp_no = updated_emp_no;
    }


    public Departments( string? dept_name, string? created_emp_no) 
    :this (null, dept_name,DateTime.UtcNow, created_emp_no, null, null) {}

    /// <summary>
    /// 部門Idのルール検証
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
    /// 部門名のルール検証
    /// </summary>
    private void ValidateDeptName(string? dept_name)
    {
        if (string.IsNullOrWhiteSpace(dept_name))
            throw new DomainException("部門名は必須です。");
        if (dept_name.Length > 50)
            throw new DomainException("部門名は50文字以内で指定してください。");
    }
    private void ValidateCreatedEmpNo(string? created_emp_no)
    {
        if (string.IsNullOrWhiteSpace(created_emp_no))
            throw new DomainException("登録者IDは必須です。");
        if (created_emp_no.Length > 20)
            throw new DomainException("登録者IDは10文字以内で指定してください。");
    }
}