using ExamEFCore.ConfigurationLibaray;
using ExamEFCore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamEFCore.LibarayDbContext
{
    public class LibarayDbConext : DbContext
    {
        public LibarayDbConext() : base()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.; Database=LibraryManagementSystem; Trusted_Connection=True; TrustServerCertificate=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Configurations
            modelBuilder.ApplyConfiguration(new BookConfiguration());
            modelBuilder.ApplyConfiguration(new AuthorConfiguration());
            modelBuilder.ApplyConfiguration(new FineConfiguration());
            modelBuilder.ApplyConfiguration(new LoanConfiguration());
            modelBuilder.ApplyConfiguration(new MemberConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration()); 
            #endregion
            #region 1 - M (Author - Book)
            modelBuilder.Entity<Book>(b =>
            { 
             b.HasOne(b => b.author).WithMany(b => b.Books)
             .HasForeignKey(a => a.AuthorId).OnDelete(DeleteBehavior.Restrict);
            }); 
            #endregion
            #region 1 -M (Book - Category)
            modelBuilder.Entity<Book>(b =>
            {
                b.HasOne(b => b.category).WithMany(c => c.Categories).HasForeignKey
                (b => b.CategoryId);
            });
            #endregion           
            #region 1 - 1 (Loan - Fine)
            modelBuilder.Entity<Fine>(f =>
            {
                f.HasOne(f => f.loan).WithOne(l => l.fine)
                .HasForeignKey<Fine>(f => f.LoanId).OnDelete(DeleteBehavior.Restrict);
            });
            #endregion
            modelBuilder.Entity<MemberLoans>(ml =>
            { ml.HasKey(ml => new { ml.LoanId, ml.BookId, ml.MemberId });
            });
            modelBuilder.Entity<MemberLoans>(ml =>
            {
                ml.HasOne(ml => ml.member).WithMany(ml => ml.memberLoans)
                .HasForeignKey(ml => ml.MemberId);

                ml.HasOne(ml => ml.loan).WithMany(l => l.memberLoans).HasForeignKey
                (ml => ml.LoanId);

                ml.HasOne(ml => ml.book).WithMany(b => b.memberLoans)
                .HasForeignKey(ml => ml.BookId);
            });          
        }
        #region Dbset
        public DbSet<Book> Books { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Loan> Loans { get; set; }
        public DbSet<Fine> Fines { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Category> categories { get; set; }
        public DbSet<MemberLoans> MemberLoans { get; set; } 
        #endregion


    }
}
