using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieAPI.Model
{
    public class ScreeningSchedule
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]

        public int ScreeningId { get; set; }

        public int ScreenNo { get; set; }   

        public DateTime StartTime { get; set; } 

        public DateTime EndTime { get; set; }

        public int MovieId { get; set; }
        public Movies movies { get; set; }  

        public ICollection<Ticket> ticket { get; set; }
    }
}
