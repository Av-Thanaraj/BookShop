using System;
using System.Collections.Generic;

namespace BookShop.Domain.Entities;

public partial class User
{
    public int Id { get; set; }

    public string? Username { get; set; }

    public string? PasswordHash { get; set; }

    public string? Email { get; set; }

    public string? Role { get; set; }

    public string? CreatedDate { get; set; }

    public string? LastLogin { get; set; }

    public virtual ICollection<Customer> Customers { get; } = new List<Customer>();
}
