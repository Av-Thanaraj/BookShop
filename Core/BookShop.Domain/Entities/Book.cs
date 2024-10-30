using System;
using System.Collections.Generic;

namespace BookShop.Domain.Entities;

public partial class Book
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public string? Author { get; set; }

    public string? Isbn { get; set; }

    public string? Genre { get; set; }

    public decimal? Price { get; set; }

    public int? Stock { get; set; }

    public string? Description { get; set; }

    public string? Publisher { get; set; }

    public DateTime? PublishedDate { get; set; }

    public string? CoverImagePath { get; set; }

    public virtual ICollection<BookGenre> BookGenres { get; } = new List<BookGenre>();

    public virtual ICollection<OrderItem> OrderItems { get; } = new List<OrderItem>();
}
