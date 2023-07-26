using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieAPI.Model
{
    public class Movies
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]

        public int MovieId { get; set; }

        public string Title { get; set; }
        public  string Genre { get; set; }
        public DateTime ReleaseDate { get; set; }

        public virtual ICollection<ScreeningSchedule> screeningSchdules { get; set; }   

    }
}
