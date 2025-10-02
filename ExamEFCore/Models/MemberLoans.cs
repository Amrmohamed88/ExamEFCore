using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamEFCore.Models
{
    public class MemberLoans
    {
        public DateTime DueDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public int MemberId { get; set; }
        public Member member { get; set; } = null!;
        public int LoanId { get; set; }
        public Loan loan { get; set; } = null!;
        public int  BookId { get; set; }
        public Book book { get; set; } = null!;


    }
}
