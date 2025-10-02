using ExamEFCore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamEFCore.ConfigurationLibaray
{
    public class LoanConfiguration : IEntityTypeConfiguration<Loan>
    {
        public void Configure(EntityTypeBuilder<Loan> L)
        {
            L.HasKey(l => l.Id);
            L.Property(b => b.LoanDate).HasDefaultValueSql("GETDATE()");
            L.Property(b => b.Status).HasConversion<string>().HasColumnType("varchar").HasMaxLength(8);
        }
    }
}
