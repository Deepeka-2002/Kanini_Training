using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieAPI.Model
{
    public class Ticket
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]

        public int TicketId { get; set; }
        public int SeatNo { get; set; }

        public DateTime BookingDate { get; set; }

        public  int UserId { get; set; }
        public User users { get; set; }

        public int ScreeningId { get; set; }
        public ScreeningSchedule screeningSchedules { get; set; }

    }
}
