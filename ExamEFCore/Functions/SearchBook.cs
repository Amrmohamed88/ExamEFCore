using ExamEFCore.LibarayDbContext;
using ExamEFCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamEFCore.Functions
{
    internal class SearchBook
    {
        public static List<Book> SearchBooks (LibarayDbConext dbConext , string Search )
        {
            try
            {
                if ( string.IsNullOrWhiteSpace ( Search ) ) 
                    return new List<Book>();

                var searchinbook = dbConext.Books.Where
                    (b => b.Title.Contains(Search)
                    || b.author.FirstName.Contains(Search)
                    || b.author.LastName.Contains(Search)
                    || b.category.Title.Contains(Search)).ToList();
                return searchinbook;
                    
            }
            catch
            {
                return new List<Book>();
            }
        }
    }
}
