using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rel2.Models
{
    public class Emp
    {
        [Key]

        [DatabaseGenerated(DatabaseGeneratedOption.None)]

        public int Empno{ get; set; } 

        public string EName { get; set; } = string.Empty;

        public  int? Deptno { get; set; }

        public virtual Dept? DeptnoNavigation { get; set; }
    }
}
