using System;
using System.Collections.Generic;

namespace FoodPortal.Models;

public partial class TrackStatus
{
    public string? OrderId { get; set; }

    public string? Status { get; set; }

    public string Id { get; set; } = null!;

    public virtual Order? Order { get; set; }
}
