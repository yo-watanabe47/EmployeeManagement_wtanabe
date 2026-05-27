using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace WebApp_Exercise.Infrastructures.Entities;

    [Table("Employees")]
    public class EmployeesEntity
    {
        [Key]
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [Column("employee_no")]
        [StringLength(50)]
        public string EmployeeNo { get; set; } = string.Empty;

        [Required]
        [Column("name")]
        [StringLength(50)]
        public string Name { get; set; } = string.Empty;
        
        [Required]
        [Column("birthday")]
        public DateOnly Birthday { get; set; }

        [Required]
        [Column("email")]
        [StringLength(100)]
        public string Email { get; set; } 
        
        [Required]
        [Column("hire_date")]
        public DateOnly HireDate { get; set; }

        [Required]
        [Column("dept_id")]
        public int DeptId { get; set; }

        [ForeignKey("DeptId")]
        public DepartmentsEntity? Departments { get; set; } 
        
        [Required]
        [Column("status")]
        public int Status { get; set; }

        [Required]
        [Column("created_at")]
        public DateTime CreatedAt { get; set; }

        [Required]
        [Column("created_no")]
        [StringLength(10)]
        public string CreatedEmpNo { get; set; } = string.Empty;

        [Column("updated_at")]
        public DateTime? UpdatedAt { get; set; }

        [Column("updated_no")]
        [StringLength(10)]
        public string? UpdatedEmpNo { get; set; }
    }
