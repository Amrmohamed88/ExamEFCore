using ExamEFCore.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamEFCore.Models
{
    public class Fine : BaseClass
    {
        public decimal Amount { get; set; }
        public DateTime IssuedDate { get; set; }
        public DateTime? PaidDate { get; set; }
        public StatusFine Status { get; set; }
        #region 1 - 1 (Loan - Fine)
        public int LoanId { get; set; }
        public Loan loan { get; set; } = null!; 
        #endregion

    }
}
