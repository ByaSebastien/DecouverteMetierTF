using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace DecouverteMetierTF.Models
{
    public class Book
    {
        public Book(BookDTO b) 
        {
            Id = null;
            Title = b.Title;
            Author = b.Author;
            Description = b.Description;
            CategoryId = b.CategoryId;
        }
        public Book() { }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Title { get; set; } = null!;

        [Required]
        [MaxLength(100)]
        public string Author { get; set; } = null!;

        public string? Description { get; set; }

        public int CategoryId { get; set; }
    }
    public class BookDTO
    {
        [Required]
        [MaxLength(100)]
        public string Title { get; set; } = null!;

        [Required]
        [MaxLength(100)]
        public string Author { get; set; } = null!;

        public string? Description { get; set; }

        public int CategoryId { get; set; }
    }
}
