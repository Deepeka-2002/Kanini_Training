using Microsoft.EntityFrameworkCore;
using Models;
using System.Collections.Generic;

namespace Users.Data
{
    public class MicroDbContext : DbContext
    {
        public MicroDbContext(DbContextOptions<MicroDbContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }


        public DbSet<Department> department { get; set; }

        public DbSet<Appointment> appointment { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    {
    }
}
