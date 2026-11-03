using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_CORE_02
{
    public class BadgeConfiguration: IEntityTypeConfiguration<Badge>
    {
        public void Configure(EntityTypeBuilder<Badge> builder)
        {
            builder.HasKey(b => b.Id);

            builder.Property(b => b.BadgeNumber).IsRequired();
            builder.HasIndex(b => b.BadgeNumber).IsUnique();

            builder.Property(b => b.IssuedDate).IsRequired();

            builder.Property(b => b.Tier)
                   .IsRequired()
                   .HasConversion<string>()
                   .HasMaxLength(20);

            // One-to-One: Attendee <-> Badge
            builder.HasOne(b => b.Attendee)
                   .WithOne(a => a.Badge)
                   .HasForeignKey<Badge>(b => b.AttendeeId)
                   .IsRequired()
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
