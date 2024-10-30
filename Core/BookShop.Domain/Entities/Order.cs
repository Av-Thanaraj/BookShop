using System;
using System.Collections.Generic;

namespace BookShop.Domain.Entities;

public partial class Order
{
    public int Id { get; set; }

    public int? CustomerId { get; set; }

    public DateTime? OrderDate { get; set; }

    public decimal? TotalAmount { get; set; }

    public string? Status { get; set; }

    public string? PaymentMethod { get; set; }

    public string? ShippingAddress { get; set; }

    public DateTime? DeliveryDate { get; set; }

    public string? TrackingNumber { get; set; }

    public virtual Customer? Customer { get; set; }

    public virtual ICollection<OrderItem> OrderItems { get; } = new List<OrderItem>();

    public virtual ICollection<Payment> Payments { get; } = new List<Payment>();
}
