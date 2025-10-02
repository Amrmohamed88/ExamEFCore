using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamEFCore.Models
{
    public class Book : BaseClass
    {
        public string Title { get; set; } = null!;
        public decimal Price { get; set; }
        public int PublicationYear { get; set; }
        public int AvailableCopies  { get; set; }
        public int TotalCopies  { get; set; }
        #region 1 - M (Author - Book)
        public int AuthorId { get; set; }
        public Author author { get; set; } = null!;
        #endregion
        #region 1 - M (Category - Book)
        public int CategoryId { get; set; }
        public Category category { get; set; } = null!;
        #endregion
        public ICollection<MemberLoans> memberLoans { get; set; } = new HashSet<MemberLoans>();
    }
}
