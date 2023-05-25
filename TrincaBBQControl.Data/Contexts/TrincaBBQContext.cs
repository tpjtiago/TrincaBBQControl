using Microsoft.EntityFrameworkCore;
using TrincaBBQControl.Domain.Entities;

namespace TrincaBBQControl.Data.Contexts
{
    public class TrincaBBQContext : DbContext
    {
        public TrincaBBQContext(DbContextOptions options)
            : base(options) { }


        public DbSet<Barbecue> Barbecue { get; set; }
        public DbSet<Participant> Participant { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TrincaBBQContext).Assembly);
        }
    }
}
