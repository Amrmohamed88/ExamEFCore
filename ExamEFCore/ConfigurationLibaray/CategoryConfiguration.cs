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
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> c)
        {
           c.HasKey(b => b.Id);
           c.Property(b => b.Title).HasColumnType("varchar(50)").HasMaxLength(50);
           c.Property(b => b.Description).HasColumnType("varchar(100)").
           HasMaxLength(100);
        }
    }
}
