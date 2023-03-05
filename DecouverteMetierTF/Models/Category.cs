using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DecouverteMetierTF.Models
{
    public class Category
    {
        public Category(CategoryDTO dto)
        {
            Name = dto.Name;
        }
        public Category() { }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = null!;
    }
    public class CategoryDTO
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = null!;
    }
}
