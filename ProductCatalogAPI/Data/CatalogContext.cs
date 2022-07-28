using EventCatalogAPI.Domain;
using Microsoft.EntityFrameworkCore;

namespace EventCatalogAPI.Data
{
    public class CatalogContext: DbContext
    {
        public CatalogContext(DbContextOptions options) : base(options) { }

        public DbSet<EventCategory> EventCategories { get; set; }
        public DbSet<EventType> EventTypes { get; set; }
        public DbSet<EventTag> EventTags { get; set; }
        public DbSet<EventOrganizer> EventOrganizers { get; set; }
        public DbSet<EventLocation> EventLocations { get; set; }
        public DbSet<EventTime> EventTimes { get; set; }
        public DbSet<EventItem> EventItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EventCategory>(e =>
            {
                e.Property(t => t.Id).IsRequired().ValueGeneratedOnAdd();
                e.Property(t => t.CategoryName).IsRequired().HasMaxLength(100);
            });

            modelBuilder.Entity<EventType>(e =>
            {
                e.Property(t => t.Id).IsRequired().ValueGeneratedOnAdd();
                e.Property(t => t.Type).
            
        }
    }
}
