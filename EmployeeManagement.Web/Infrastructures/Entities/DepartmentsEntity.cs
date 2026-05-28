using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace WebApp_Exercise.Infrastructures.Entities;

    [Table("Departments")]
    public class DepartmentsEntity
    {
        [Key]
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? Id { get; set; }

        [Required]
        [Column("dept_name")]
        [StringLength(50)]
        public string? DeptName { get; set; } = string.Empty;

        [Required]
        [Column("created_at")]
        public DateTime? CreatedAt { get; set; } = DateTime.UtcNow;

        [Required]
        [Column("created_emp_no")]
        [StringLength(10)]
        public string? CreatedEmpNo { get; set; } = string.Empty;

        [Column("updated_at")]
        public DateTime? UpdatedAt { get; set; }

        [Column("updated_emp_no")]
        [StringLength(10)]
        public string? UpdatedEmpNo { get; set; }
    }
