using System;
using System.Collections.Generic;

namespace BookShop.Domain.Entities;

public partial class Genre
{
    public int Id { get; set; }

    public string? GenreName { get; set; }

    public virtual ICollection<BookGenre> BookGenres { get; } = new List<BookGenre>();
}
