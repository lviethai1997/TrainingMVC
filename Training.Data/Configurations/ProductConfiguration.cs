using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using Training.Data.Entities;

namespace Training.Data.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Price).IsRequired();
            builder.Property(x => x.PriceIn).IsRequired();
            builder.Property(x => x.Thunbar).IsRequired();
            builder.Property(x => x.Content).IsRequired().HasMaxLength(int.MaxValue);
            builder.Property(x => x.Sale).HasDefaultValue(0.0);
            builder.Property(x => x.Quantity).IsRequired();
            builder.Property(x => x.ViewCount).HasDefaultValue(0);
            builder.Property(x => x.Hot).HasDefaultValue(1);
            builder.Property(x => x.Status).HasDefaultValue(0);
            builder.Property(x => x.Created_time).HasDefaultValue(DateTime.Now);
            builder.Property(x => x.Updated_time).HasDefaultValue(DateTime.Now);

            builder.HasOne(x => x.ProductCategory).WithMany(x => x.products).HasForeignKey(x => x.CategoryId);
        }
    }
}