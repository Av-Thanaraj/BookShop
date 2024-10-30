using System;
using System.Collections.Generic;

namespace BookShop.Domain.Entities;

public partial class Customer
{
    public int Id { get; set; }

    public int? UserId { get; set; }

    public string? FullName { get; set; }

    public string? PhoneNumber { get; set; }

    public string? Address { get; set; }

    public string? City { get; set; }

    public string? Country { get; set; }

    public string? PostalCode { get; set; }

    public virtual ICollection<Order> Orders { get; } = new List<Order>();

    public virtual User? User { get; set; }
}
