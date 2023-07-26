using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using RequiredAttribute = Microsoft.Build.Framework.RequiredAttribute;

namespace Rel2.Models
{
    public class EmpDetails
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Empno { get; set; }
        [Required]
        public long AadharNo { get; set;}
        [Required]
        public string PanNo { get; set; }

    }
}
