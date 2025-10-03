using ExamEFCore.ConfigurationLibaray;
using ExamEFCore.LibarayDbContext;
using ExamEFCore.Models;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamEFCore.Functions
{
    internal class BorrowBook
    {
        public static bool BorrowBooks (LibarayDbConext dbConext , int BookId , int MemberId)
        {
           try
            {
                var Book = dbConext.Books.Find(BookId);
                var Member = dbConext.Members.Find(MemberId);

                if (Book == null || Member == null || Book.AvailableCopies <= 0)
                    return false;

                var loan = new Loan
                {
                    LoanDate = DateOnly.FromDateTime(DateTime.Now),
                    Status = Enum.StatusLoan.Borrowed
                };

                var memberLoans = new MemberLoans
                {
                    BookId = BookId,
                    MemberId = MemberId,
                    DueDate = DateTime.Now.AddDays(14),
                    loan = loan
                };

               
                Book.AvailableCopies -= 1;
                dbConext.Loans.Add(loan);
                dbConext.MemberLoans.Add(memberLoans);
                return dbConext.SaveChanges() > 0;
            }
            catch
            {
                return false;
            }

            
        }
    }
}
