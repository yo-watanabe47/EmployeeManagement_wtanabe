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
        // ValidateId(id);
        // ValidateEmployeeNo(employee_No);
        // ValidateDeptName(Name);
        // ValidateBirthday(birthday);
        // ValidateEmail(email);
        // ValidateHireDate(hireDate);
        // ValidateDeptId(deptId);
        // ValidateStatus(status);
        // ValidateCreatedEmpNo(created_emp_no);
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
        string? name,
        DateOnly birthday,
        string email,
        DateOnly hireDate,
        int deptId,
        int status,
        DateTime created_at,
        string? created_emp_no) 
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

 
}