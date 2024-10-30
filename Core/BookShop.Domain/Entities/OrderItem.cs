﻿using System;
using System.Collections.Generic;

namespace BookShop.Domain.Entities;

public partial class OrderItem
{
    public int Id { get; set; }

    public int? OrderId { get; set; }

    public int? BookId { get; set; }

    public int? Quantity { get; set; }

    public decimal? Price { get; set; }

    public virtual Book? Book { get; set; }

    public virtual Order? Order { get; set; }
}
