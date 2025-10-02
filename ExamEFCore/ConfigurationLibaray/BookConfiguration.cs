using ExamEFCore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
    
namespace ExamEFCore.ConfigurationLibaray
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> b)
        {
            b.HasKey(b => b.Id);
            b.Property(b => b.Title).HasColumnType("varchar(50)").HasMaxLength(50);
            b.Property(b => b.Price).HasColumnType("decimal(6,2)");
            b.ToTable(b =>
            {
                b.HasCheckConstraint("CheckBookPublicationYear", "[PublicationYear] BETWEEN 1950 AND YEAR(GETDATE())");
                b.HasCheckConstraint("CheckAvailableCopies", "[AvailableCopies] <= [TotalCopies]");
            });
        }
    }
}
