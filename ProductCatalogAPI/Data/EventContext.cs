using EventCatalogAPI.Domain;
using Microsoft.EntityFrameworkCore;

namespace EventCatalogAPI.Data
{
    public class EventContext : DbContext
    {
        public EventContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<EventLocation> EventLocations { get; set; }
        public DbSet<EventCatagory> EventCatagories { get; set; }
        public DbSet<EventItem> EventItems { get; set; }
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

            modelBuilder.Entity<EventCatagory>(e =>
            {
                e.Property(t => t.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();

                e.Property(t => t.Category)
                .IsRequired()
                .HasMaxLength(100);
            });

            modelBuilder.Entity<EventItem>(e =>
            {
                e.Property(t => t.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();

                e.Property(t => t.Name)
                 .IsRequired()
                .HasMaxLength(100);

                e.Property(t => t.Price)
                 .IsRequired();

                e.Property(t => t.EventDate)
                 .IsRequired();

                e.Property(t => t.Address)
                 .IsRequired();

                e.Property(t => t.Organizer)
                .IsRequired();

                e.HasOne(t => t.EventCatagory)
                   .WithMany()
                   .HasForeignKey(t => t.EventCatagoryId);

                e.HasOne(t => t.EventLocation)
                .WithMany()
                .HasForeignKey(t => t.EventLocationId);
            });

        }
    }
}