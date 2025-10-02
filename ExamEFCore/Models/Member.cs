using ExamEFCore.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamEFCore.Models
{
    public class Member : BaseClass
    {
        public string Name { get; set; } = null!;
        public String? Address { get; set; }
        public string Email { get; set; } = null!;
        public string? PhoneNumber { get; set; }
        public DateTime MembershipDate { get; set; }
        public MemberStatus status { get; set; }
        public ICollection<MemberLoans> memberLoans { get; set; } = new HashSet<MemberLoans>();
    }
}
