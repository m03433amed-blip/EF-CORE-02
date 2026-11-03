using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_CORE_02
{
    public class EventConfiguration: IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Title)
                   .IsRequired()
                   .HasMaxLength(200);

            builder.Property(e => e.Description)
                   .IsRequired()
                   .HasMaxLength(2000);

            builder.Property(e => e.StartDate).IsRequired();
            builder.Property(e => e.EndDate).IsRequired(false);
            builder.Property(e => e.MaxAttendees).IsRequired();

            // One-to-Many: Organizer -> Events
            builder.HasOne(e => e.Organizer)
                   .WithMany(o => o.Events)
                   .HasForeignKey(e => e.OrganizerId)
                   .IsRequired()
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
