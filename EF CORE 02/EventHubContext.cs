using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_CORE_02
{
    public class EventHubContext : DbContext
    {
        public EventHubContext(): base() 
        {
            
        }
        public DbSet<Organizer> Organizers { get; set; }
        public DbSet<OrganizerProfile> OrganizerProfiles { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Attendee> Attendees { get; set; }
        public DbSet<Badge> Badges { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Server=.;Database=EventHubDb;Trusted_Connection=True;TrustServerCertificate=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Way 1: Fluent API directly inside OnModelCreating
            modelBuilder.Entity<OrganizerProfile>(entity =>
            {
                entity.HasKey(p => p.Id);

                entity.Property(p => p.Bio).HasMaxLength(1000);
                entity.Property(p => p.WebsiteUrl).HasMaxLength(300);
                entity.Property(p => p.LogoUrl).HasMaxLength(300);

                // One-to-One: Organizer <-> OrganizerProfile
                entity.HasOne(p => p.Organizer)
                      .WithOne(o => o.Profile)
                      .HasForeignKey<OrganizerProfile>(p => p.OrganizerId)
                      .IsRequired()
                      .OnDelete(DeleteBehavior.Cascade);
            });

            // Way 2: Fluent API in separate configuration classes
            modelBuilder.ApplyConfiguration(new EventConfiguration());
            modelBuilder.ApplyConfiguration(new BadgeConfiguration());
        }
    }
}
