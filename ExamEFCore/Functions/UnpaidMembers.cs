using ExamEFCore.Enum;
using ExamEFCore.LibarayDbContext;
using ExamEFCore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamEFCore.Functions
{
    internal class UnpaidMembers
    {
        public static bool UnpaidMember (LibarayDbConext dbConext ,int memberId)
        {
            try
            {
                var member = dbConext.Members.FirstOrDefault(m => m.Id == memberId);
  
                 if(member is null) 
                    return false;

                member.status = MemberStatus.Suspended;
                    return dbConext.SaveChanges() > 0; 
            }
            catch
            {
                return false;
            }
        }
    }
}
