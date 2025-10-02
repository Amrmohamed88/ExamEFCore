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
    public class MemberConfiguration : IEntityTypeConfiguration<Member>
    {
        public void Configure(EntityTypeBuilder<Member> M)
        {
            M.Property(b => b.Id);
            M.Property(b => b.Email).HasColumnType("varchar(100)").HasMaxLength(100);
            M.ToTable(b =>
            {
                b.HasCheckConstraint("CheckEmail", "[Email] LIKE '_%@_%._%'");
            });
            M.Property(b => b.Name).HasColumnType("varchar(50)").HasMaxLength(50);
            M.Property(b => b.PhoneNumber).HasMaxLength(11).HasColumnType("varchar(11)");
            M.ToTable(b =>
            {
                b.HasCheckConstraint("CheckPhoneNumber", "[PhoneNumber] LIKE '01%' AND LEN ([PhoneNumber])= 11");
                b.HasCheckConstraint("CheckPhoneNumber", "[PhoneNumber] NOT LIKE '[^a-z]' ");
            });
            M.Property(b => b.Address).HasColumnType("varchar(100)").HasMaxLength(100);
            M.Property(b => b.MembershipDate).HasDefaultValueSql("GETDATE()");
            M.Property( b => b.status).HasConversion<string>().HasColumnType("varchar").HasMaxLength(10);

        }
    }
}
