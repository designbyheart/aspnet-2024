using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace MySQLDemo.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; } // Primary Key

        [Required]
        [StringLength(100)]
        public string Name { get; set; } // Name of the category

        [StringLength(500)]
        public string Description { get; set; } // Optional description of the category

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow; // Date the category was created

        public DateTime? UpdatedAt { get; set; } // Date the category was last updated

        // Navigation property to link with Products
        public ICollection<Product> Products { get; set; } // List of products in this category
    }

}
