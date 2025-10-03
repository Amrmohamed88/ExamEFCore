using ExamEFCore.Enum;
using ExamEFCore.LibarayDbContext;
using ExamEFCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamEFCore.Functions
{
    internal class ReturnBook
    {
        public static bool ReturnBooks (LibarayDbConext dbConext ,int LoanId , bool IsDamaged=false)
        {
            try
            {
             var loan = dbConext.Loans.Find ( LoanId );
             if( loan == null || loan.Status != StatusLoan.Borrowed ) 
                return false; 

             var memberloan = dbConext.MemberLoans.FirstOrDefault(ml => ml.LoanId == LoanId );
                if(memberloan is null)
                    return false;

                var Book = dbConext.Books.Find (memberloan.BookId);
                if ( Book is null ) 
                    return false;

                Book.AvailableCopies += 1;

                if(IsDamaged || memberloan.DueDate < DateTime.Now )
                {
                    var fine = new Fine
                    {
                         Amount = IsDamaged ? 5 :10,
                         IssuedDate = DateTime.Now,
                         loan = loan,
                    };
                    var memberLoan = new MemberLoans
                    {
                        MemberId = memberloan.MemberId                        
                    };
                    dbConext.Fines.Add(fine);
                }
                loan.Status = StatusLoan.Returned;
                return dbConext.SaveChanges() > 0;
            }
            catch
            {
             return false;
            }
        }   
    }
}
