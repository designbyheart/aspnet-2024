using System.ComponentModel.DataAnnotations;

namespace MySQLDemo.Models
{

    public class Order
    {
        [Key]
        public int Id { get; set; } // Primary Key

        [Required]
        public DateTime OrderDate { get; set; } = DateTime.UtcNow; // Date the order was placed

        [Required]
        public string CustomerName { get; set; } // Name of the customer who placed the order

        [Required]
        [StringLength(200)]
        public string CustomerEmail { get; set; } // Email of the customer

        [Required]
        public string ShippingAddress { get; set; } // Address where the order should be delivered

        [Required]
        public decimal TotalAmount { get; set; } // Total cost of the order

        public DateTime? DeliveredAt { get; set; } // Date the order was delivered (nullable)

        // Navigation property to link with OrderItems
        public ICollection<OrderItem> OrderItems { get; set; } // Items in this order
    }
}
