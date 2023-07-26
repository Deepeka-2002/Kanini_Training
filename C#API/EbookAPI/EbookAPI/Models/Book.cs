using System;
using System.Collections.Generic;

namespace EbookAPI.Models;

public partial class Book
{
    public int? Categoryid { get; set; }

    public string? Title { get; set; }

    public string? Author { get; set; }

    public string Isbn { get; set; } = null!;

    public string? Publisher { get; set; }

    public int? Edition { get; set; }

    public string? Language { get; set; }

    public virtual Category? Category { get; set; }
}
