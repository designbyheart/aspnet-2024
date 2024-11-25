using System;
using System.Collections.Generic;

namespace FrontEndDemo.Models;

public partial class Order
{
    public int Id { get; set; }

    public DateTime OrderDate { get; set; }

    public string CustomerName { get; set; } = null!;

    public string CustomerEmail { get; set; } = null!;

    public string ShippingAddress { get; set; } = null!;

    public decimal TotalAmount { get; set; }

    public DateTime? DeliveredAt { get; set; }

    public virtual ICollection<Orderitem> Orderitems { get; set; } = new List<Orderitem>();
}
