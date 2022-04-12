using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using Training.Data.Entities;

namespace Training.Data.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Email).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Phone).IsRequired().HasMaxLength(15);
            builder.Property(x => x.Address).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Username).IsRequired().IsUnicode(false).HasMaxLength(30);
            builder.Property(x => x.Password).IsRequired().IsUnicode(false).HasMaxLength(30);
            builder.Property(x => x.Role).IsRequired().HasDefaultValue(0);
            builder.Property(x => x.Status).IsRequired().HasDefaultValue(0);
            builder.Property(x => x.Created_time).HasDefaultValue(DateTime.Now);
            builder.Property(x => x.Updated_time).HasDefaultValue(DateTime.Now);
        }
    }
}