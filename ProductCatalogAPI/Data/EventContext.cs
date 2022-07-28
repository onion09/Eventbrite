using EventCatalogAPI.Domain;
using Microsoft.EntityFrameworkCore;

namespace EventCatalogAPI.Data
{
    public class EventContext:DbContext
    {
        public EventContext(DbContextOptions options): base(options)
        {

        }

        public DbSet<EventLocation> EventLocations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EventLocation>(e =>
            {
                e.Property(t => t.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();


                e.Property(t => t.City)
                .IsRequired()
                .HasMaxLength(100);
            });
          
        }
    }
}
