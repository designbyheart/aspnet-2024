using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using MySQLDemo.Models;
using System.Linq;

namespace MySQLDemo.Controllers
{
    public partial class OrdersController
    {
        // POST: api/Orders/CreateWithItems
        [HttpPost("CreateWithItems")]
        public async Task<ActionResult<Order>> CreateOrderWithItems([FromBody] List<OrderItemDto> orderItemsDto)
        {
            if (orderItemsDto == null || !orderItemsDto.Any())
            {
                return BadRequest("Order items cannot be empty.");
            }

            var productIds = orderItemsDto.Select(i => i.ProductId).Distinct();
            var products = await _context.Products
                .Where(p => productIds.Contains(p.Id))
                .ToListAsync();

            if (products.Count != productIds.Count())
            {
                return BadRequest("One or more products are invalid.");
            }

            var newOrder = new Order
            {
                CustomerName = "Generated Customer",
                CustomerEmail = "customer@example.com",
                ShippingAddress = "123 Default Address",
                OrderDate = DateTime.UtcNow,
                TotalAmount = orderItemsDto.Sum(i => i.Price * i.Quantity),
                OrderItems = new List<OrderItem>()
            };

            foreach (var itemDto in orderItemsDto)
            {
                var product = products.FirstOrDefault(p => p.Id == itemDto.ProductId);
                if (product != null)
                {
                    newOrder.OrderItems.Add(new OrderItem
                    {
                        ProductId = product.Id,
                        Quantity = itemDto.Quantity,
                        Price = itemDto.Price
                    });
                }
            }

            _context.Orders.Add(newOrder);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetOrder), new { id = newOrder.Id }, newOrder);
        }

        public class OrderItemDto
        {
            public int ProductId { get; set; }
            public int Quantity { get; set; }
            public decimal Price { get; set; }
        }
    }
}
