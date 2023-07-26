using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Appointment
    {
        [Key]
        public int AppointmentId { get; set; }

        public string userEmail { get; set; } = string.Empty;

        public string PatientName { get; set; } = string.Empty;

        public int Age { get; set; }

        public string Gender { get; set; } = string.Empty;
        public string DiseaseDescription { get; set; } = string.Empty;
        public DateTime AppointmentSchedule { get; set; }

        public int Id { get; set; }
        public User? Users { get; set; }
    }
}
