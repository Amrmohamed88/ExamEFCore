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
    public class AuthorConfiguration : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> A)
        {
            A.HasKey( a => a.Id);
            A.Property( a => a.FirstName).HasColumnType("varchar(50)").HasMaxLength(20);
            A.Property( a => a.LastName).HasColumnType("varchar(50)").HasMaxLength(20);
        }
    }
}
