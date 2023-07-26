using System;
using System.Collections.Generic;

namespace EbookAPI.Models;

public partial class BookBorrow
{
    public int Borrowid { get; set; }

    public string Isbn { get; set; } = null!;

    public DateTime? BorrowDate { get; set; }

    public DateTime? DueDate { get; set; }

    public DateTime? ReturnDate { get; set; }

    public virtual BookBorrowMaster Borrow { get; set; } = null!;

    public virtual Book IsbnNavigation { get; set; } = null!;
}
