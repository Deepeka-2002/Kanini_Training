using System;
using System.Collections.Generic;

namespace EbookAPI.Models;

public partial class User
{
    public int Userid { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public string? Address { get; set; }

    public string? City { get; set; }

    public string? State1 { get; set; }

    public string? Gender { get; set; }

    public string? UserType { get; set; }

    public virtual ICollection<BookBorrowMaster> BookBorrowMasters { get; set; } = new List<BookBorrowMaster>();
}
