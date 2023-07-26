using System;
using System.Collections.Generic;

namespace EbookAPI.Models;

public partial class Subscriptiondetail
{
    public int? Userid { get; set; }

    public DateTime? SubStartdate { get; set; }

    public DateTime? SubEnddate { get; set; }

    public int? AmountRupees { get; set; }

    public virtual User? User { get; set; }
}
