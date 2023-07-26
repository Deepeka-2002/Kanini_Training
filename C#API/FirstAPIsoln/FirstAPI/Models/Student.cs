using System.Diagnostics;

namespace FirstAPI.Models
{
    public class Student
    {
        public int StudId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;

        public int Pin{ get; set; }

    }
}
