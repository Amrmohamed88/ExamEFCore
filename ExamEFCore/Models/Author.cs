using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamEFCore.Models
{
    public class Author : BaseClass
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!; 
        public DateOnly DateOfBirth { get; set; }
        public ICollection<Book> Books { get; set; } = new HashSet<Book>();
    }
}
