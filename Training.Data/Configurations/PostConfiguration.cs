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
    public class PostConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.ToTable("Posts");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.Title).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Content).IsRequired().HasMaxLength(255);
            builder.Property(x => x.ContentMini).IsRequired().HasMaxLength(255);
            builder.Property(x => x.ImageBanner).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Status).HasDefaultValue(0);
            builder.Property(x => x.Created_time).HasDefaultValue(DateTime.Now);
            builder.Property(x => x.Updated_time).HasDefaultValue(DateTime.Now);

            builder.HasOne(x => x.PostCategory).WithMany(x => x.Posts).HasForeignKey(x => x.PostCateId);
            builder.HasOne(x => x.User).WithMany(x => x.Posts).HasForeignKey(x => x.UserId);
        }
    }
}
