using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Training.Data.Entities;

namespace Training.Data.Configurations
{
    public class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            builder.ToTable("Transactions");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).UseIdentityColumn();
            builder.Property(t => t.Status).HasDefaultValue(0);

            builder.HasOne(t => t.Order).WithMany(t => t.Transactions).HasForeignKey(t => t.OrderId);
            builder.HasOne(t => t.User).WithMany(t => t.Transactions).HasForeignKey(t => t.UserId);
        }
    }
}