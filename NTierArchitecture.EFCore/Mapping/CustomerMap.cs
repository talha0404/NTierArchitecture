using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NTierArchtitecture.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierArchitecture.EFCore.Mapping
{
    public class CustomerMap: IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> modelBuilder)
        {
            modelBuilder.HasKey(a => a.Id);
            modelBuilder.HasIndex(u => u.Guid).IsUnique(true);
            modelBuilder.Property(b => b.RecordDate).HasDefaultValueSql("getdate()");
            modelBuilder.ToTable(nameof(Customer));
        }
    }
}
