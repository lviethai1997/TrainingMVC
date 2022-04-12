using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Training.Data.Entities;

namespace Training.Data.Configurations
{
    public class PostCategoryConfiguration : IEntityTypeConfiguration<PostCategory>
    {
        public void Configure(EntityTypeBuilder<PostCategory> builder)
        {
            builder.ToTable("PostCategories");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.Name).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Show).HasDefaultValue(0);
            builder.Property(x => x.Status).HasDefaultValue(0);
            builder.Property(x => x.Created_time).HasDefaultValue(DateTime.Now);
            builder.Property(x => x.Updated_time).HasDefaultValue(DateTime.Now);
        }
    }
}
