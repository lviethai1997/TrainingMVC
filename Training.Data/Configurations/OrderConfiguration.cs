using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using Training.Data.Entities;

namespace Training.Data.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Orders");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.CustommerAdress).IsRequired().HasMaxLength(300);
            builder.Property(x => x.CustommerName).IsRequired().HasMaxLength(100);
            builder.Property(x => x.CustommerEmail).IsRequired().HasMaxLength(50);
            builder.Property(x => x.CustommerPhone).IsRequired().HasMaxLength(15);
            builder.Property(x => x.Status).HasDefaultValue(0);
            builder.Property(x => x.Created_time).HasDefaultValue(DateTime.Now);

            builder.HasOne(x => x.User).WithMany(x => x.Orders).HasForeignKey(x => x.UserId);
        }
    }
}