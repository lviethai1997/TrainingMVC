using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using Training.Data.Entities;

namespace Training.Data.Configurations
{
    public class ProductCategoryConfiguration : IEntityTypeConfiguration<ProductCategory>
    {
        public void Configure(EntityTypeBuilder<ProductCategory> builder)
        {
            builder.ToTable("ProductCategories");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.SaleCate).HasDefaultValue(0);
            builder.Property(x => x.ParentId).IsRequired();
            builder.Property(x => x.Banner).IsRequired();
            builder.Property(x => x.Show).HasDefaultValue(1);
            builder.Property(x => x.Status).HasDefaultValue(0);
            builder.Property(x => x.Created_time).HasDefaultValue(DateTime.Now);
            builder.Property(x => x.Created_time).HasDefaultValue(DateTime.Now);
        }
    }
}