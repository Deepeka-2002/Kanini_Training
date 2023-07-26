using System;
using System.Collections.Generic;

namespace WebAPIwithDBFirst.Models;

public partial class Student
{
    public int StudId { get; set; }

    public string Name { get; set; } = null!;

    public string City { get; set; } = null!;

    public int Pin { get; set; }
}
