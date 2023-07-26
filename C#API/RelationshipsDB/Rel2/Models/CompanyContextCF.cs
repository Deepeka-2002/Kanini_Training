using Microsoft.EntityFrameworkCore;

namespace Rel2.Models
{
    public class CompanyContextCF : DbContext
    {
        public CompanyContextCF(DbContextOptions<CompanyContextCF>options) : base(options)
        {
            
        }
        public DbSet<Dept> Depts { get; set; }

        public DbSet<Emp> Emps { get; set; }

        public DbSet<EmpDetails> EmpDetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }
}
