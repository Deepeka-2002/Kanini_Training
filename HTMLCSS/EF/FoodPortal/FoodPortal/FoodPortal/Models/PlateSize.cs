using System;
using System.Collections.Generic;

namespace FoodPortal.Models;

public partial class PlateSize
{
    public int Id { get; set; }

    public string PlateType { get; set; } = null!;

    public decimal? VegPlateCost { get; set; }

    public decimal? NonvegPlateCost { get; set; }

    public string? Menu { get; set; }

    public virtual ICollection<FoodTypeCount> FoodTypeCounts { get; set; } = new List<FoodTypeCount>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
