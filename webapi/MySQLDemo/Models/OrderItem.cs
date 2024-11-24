using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MySQLDemo.Models
{
    public class OrderItem
    {
        [Key]
        public int Id { get; set; } // Primary Key

        [Required]
        public int OrderId { get; set; } // Foreign Key for Order

        [ForeignKey("OrderId")]
        public Order Order { get; set; } // Navigation Property

        [Required]
        public int ProductId { get; set; } // Foreign Key for Product

        [ForeignKey("ProductId")]
        public Product Product { get; set; } // Navigation Property

        [Required]
        public int Quantity { get; set; } // Quantity of the product

        [Required]
        public decimal Price { get; set; } // Price of the product at the time of the order
    }
}
