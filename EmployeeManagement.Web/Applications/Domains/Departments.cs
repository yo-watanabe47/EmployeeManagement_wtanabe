using WebApp_Exercise.Exceptions;
namespace WebApp_Exercise.Applications.Domains;
/// <summary>
/// 商品を表すドメインオブジェクト
/// </summary>
public class Departments 
{

    public int Id { get; private set; }      

    public string Dept_name { get; init; } = string.Empty;    

    public DateTime Created_at { get; init; } = DateTime.Now;

    public string Created_emp_no { get; init; } = string.Empty;

    public DateTime? Updated_at { get; init; } = DateTime.Now;
    
    public string? Updated_emp_no { get; init; } = null;

    public Departments(int id , string dept_name , DateTime created_at, string created_emp_no, DateTime? updated_at, string? updated_emp_no)
    {
        Id = id;
        Dept_name = dept_name;
        Created_at = created_at;
        Created_emp_no = created_emp_no;
        Updated_at = updated_at;
        Updated_emp_no = updated_emp_no;
    }

 
}