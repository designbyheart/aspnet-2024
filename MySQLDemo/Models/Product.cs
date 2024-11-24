using System.ComponentModel.DataAnnotations;

namespace MySQLDemo.Models
{

    public class Product
    {
        [Key]
        public int Id { get; set; } // Primary Key

        [Required]
        [StringLength(100)]
        public string Name { get; set; } // Name of the product

        [Required]
        [StringLength(500)]
        public string Description { get; set; } // Description of the product

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than zero.")]
        public decimal Price { get; set; } // Price of the product

        [Required]
        public int Stock { get; set; } // Available stock count

        [Required]
        public string Category { get; set; } // Product category

        [DataType(DataType.Date)]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow; // Date the product was created

        [DataType(DataType.Date)]
        public DateTime? UpdatedAt { get; set; } // Date the product was last updated

        public int CategoryId { get; set; } // Foreign Key
    }
}
