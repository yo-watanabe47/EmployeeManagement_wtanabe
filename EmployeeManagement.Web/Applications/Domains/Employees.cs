using WebApp_Exercise.Exceptions;
namespace WebApp_Exercise.Applications.Domains;

public class Employees 
{

        public int? Id { get; private set; }      
        public string Employee_No { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public DateOnly Birthday { get; set; }
        public string Email { get; set; } 
        public DateOnly HireDate { get; set; }
        public int DeptId { get; set; } 
        public int Status { get; set; } 
        public DateTime Created_at { get; init; } = DateTime.Now;
        public string Created_emp_no { get; init; } = string.Empty;
        public DateTime? Updated_at { get; init; } = DateTime.Now;
        public string? Updated_emp_no { get; init; } = null;
        public String? DeptName { get; set; }

    public Employees(
        int? id ,
        string employee_No ,
        string name,
        DateOnly birthday,
        string email,
        DateOnly hireDate,
        int deptId,
        int status,
        DateTime created_at,
        string created_emp_no,
        DateTime? updated_at,
        string? updated_emp_no,
        String? deptName)
    {
        ValidateId(id);
        ValidateEmployeeNo(employee_No);
        ValidateName(name);
        ValidateBirthday(birthday);
        ValidateEmail(email);
        ValidateHireDate(hireDate);
        ValidateDeptId(deptId);
        ValidateCreatedEmpNo(created_emp_no);
        Id = id;
        Employee_No = employee_No;
        Name = name;
        Birthday = birthday;
        Email = email;
        HireDate = hireDate;
        DeptId = deptId;
        Status = status;
        Created_at = created_at;
        Created_emp_no = created_emp_no;
        Updated_at = updated_at;
        Updated_emp_no = updated_emp_no;
        DeptName = deptName;
    }

    public Employees(
        string employee_No,
        string name,
        DateOnly birthday,
        string email,
        DateOnly hireDate,
        int deptId,
        int status,
        DateTime created_at,
        string created_emp_no) 
    :this (
        null,
        employee_No, 
        name,
        birthday,
        email,
        hireDate,
        deptId,
        status,
        DateTime.UtcNow,
        created_emp_no,
        null,
        null,
        null) {}


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
    private void ValidateEmployeeNo(string? employee_No)
    {
        if (string.IsNullOrWhiteSpace(employee_No))
            throw new DomainException("社員番号は必須です。");
        if (employee_No.Length > 10)
            throw new DomainException("社員番号は10文字以内で指定してください。");
    }
        private void ValidateName(string? name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new DomainException("氏名は必須です。");
        if (name.Length > 50)
            throw new DomainException("氏名は50文字以内で指定してください。");
    }
        private void ValidateBirthday(DateOnly birthday)
    {
        if (birthday == DateOnly.MinValue)
            throw new DomainException("生年月日は必須です。");
    }
        private void ValidateEmail(string? email)
    {
        if (string.IsNullOrWhiteSpace(email))
            throw new DomainException("メールアドレスは必須です。");
        if (email.Length > 100)
            throw new DomainException("メールアドレスは100文字以内で指定してください。");
    }
    
        private void ValidateHireDate(DateOnly hireDate)
    {
        if (hireDate == DateOnly.MinValue)
            throw new DomainException("入社日は必須です。");
    
    }
        private void ValidateDeptId(int? deptId)
    {
        if (deptId == null || deptId <= 0)
            throw new DomainException("部署IDは必須です。");
    }
        private void ValidateCreatedEmpNo(string? created_emp_no)
    {
        if (string.IsNullOrWhiteSpace(created_emp_no))
            throw new DomainException("登録者IDは必須です。");
        if (created_emp_no.Length > 10)
            throw new DomainException("登録者IDは10文字以内で指定してください。");
    }

}