using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace WebApp_Exercise.Infrastructures.Entities;

    [Table("Login")]
    public class LoginEntity
    {
        [Key]
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [Column("login_id")]
        [StringLength(10)]
        public string LoginId { get; set; } = string.Empty;

        [Required]
        [Column("pass")]
        [StringLength(250)]
        public string Pass { get; set; } = string.Empty;
        
    }
