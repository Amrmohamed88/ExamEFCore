using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamEFCore.Models
{
    public class Category : BaseClass
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public ICollection<Book> Categories { get; set; } = new HashSet<Book>();
        
    }
}
