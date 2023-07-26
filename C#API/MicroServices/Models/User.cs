using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class User
    {
        [Key]

        public int Id { get; set; }
        public string? Email { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;

        public bool AvailableStatus { get; set; }


        /*[Column(TypeName = "Date")]*/
        /*public DateTime DateOfBirth { get; set; }*/
        public string Gender { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;

        public string DepName { get; set; }
        public Department? department { get; set; }

        public ICollection<Appointment>? appointment { get; set; }
    }
}
