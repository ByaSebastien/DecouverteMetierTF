using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DecouverteMetierTF.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Username { get; set; } = null!;

        [Required]
        [MaxLength(100)]
        public string Email { get; set; } = null!;

        [Required]
        [MaxLength(50)]
        public string Password { get; set; } = null!;
    }
    public class UserRegisterDTO
    {

        [Required]
        [MaxLength(50)]
        public string Username { get; set; } = null!;

        [Required]
        [MaxLength(100)]
        public string Email { get; set; } = null!;

        [Required]
        [MaxLength(50)]
        public string Password { get; set; } = null!;
    }
    public class UserLoginDTO
    {

        [Required]
        [MaxLength(100)]
        public string Login { get; set; } = null!;

        [Required]
        [MaxLength(50)]
        public string Password { get; set; } = null!;
    }
}
