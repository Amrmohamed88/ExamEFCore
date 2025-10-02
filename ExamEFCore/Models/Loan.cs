
using ExamEFCore.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamEFCore.Models
{
    public class Loan : BaseClass
    {
        public DateOnly LoanDate { get; set; }
        public StatusLoan Status { get; set; }
        public Fine? fine { get; set; }
        public ICollection<MemberLoans> memberLoans { get; set; } = new HashSet<MemberLoans>();


    }
}
