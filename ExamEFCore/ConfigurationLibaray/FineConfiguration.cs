using ExamEFCore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamEFCore.ConfigurationLibaray
{
    public class FineConfiguration : IEntityTypeConfiguration<Fine>
    {
        public void Configure(EntityTypeBuilder<Fine> F)
        {
            F.HasKey(F => F.Id);
            F.Property(F => F.Amount).HasColumnType("decimal(6,2)");
            F.Property(F => F.IssuedDate).HasDefaultValueSql("GETDATE()");
            F.Property(F => F.PaidDate);
            F.Property(F => F.Status).HasConversion<string>().HasColumnType("varchar").HasMaxLength(8);

        }
    }
}
