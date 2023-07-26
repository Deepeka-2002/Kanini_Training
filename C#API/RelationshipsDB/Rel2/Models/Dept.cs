using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rel2.Models
{
    public class Dept
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]

        public int Deptno { get; set; }

        [Required]
        public string Deptname { get; set; }  = string.Empty;
       
        public virtual ICollection<Emp>? Emps { get; set; }
    }
}
