using System;
using System.Collections.Generic;

namespace EbookAPI.Models;

public partial class BookBorrowMaster
{
    public int Borrowid { get; set; }

    public int? Userid { get; set; }

    public int? FineRupees { get; set; }

    public virtual User? User { get; set; }
}
