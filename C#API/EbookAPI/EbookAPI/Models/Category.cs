using System;
using System.Collections.Generic;

namespace EbookAPI.Models;

public partial class Category
{
    public int Categoryid { get; set; }

    public string? CategoryName { get; set; }

    public virtual ICollection<Book> Books { get; set; } = new List<Book>();
}
