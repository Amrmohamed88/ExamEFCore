using ExamEFCore.Functions;
using ExamEFCore.LibarayDbContext;
using ExamEFCore.Models;

namespace ExamEFCore
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region DataSeeding
            //using LibarayDbConext dbConext = new LibarayDbConext();
            //bool DataSeeding = LibarayDbcontextSeeding.AuthorSeeding(dbConext);
            //if (DataSeeding)
            //{
            //    Console.WriteLine("data seeding succes");
            //}
            //else
            //    Console.WriteLine("data seeding Failed");



            //using LibarayDbConext dbConext = new LibarayDbConext();

            //bool DataSeeding = LibarayDbcontextSeeding.CategorySeeding(dbConext);
            //if (DataSeeding)
            //{
            //    Console.WriteLine("data seeding succes");
            //}
            //else
            //    Console.WriteLine("data seeding Failed");


            //using LibarayDbConext dbConext = new LibarayDbConext();

            //bool DataSeeding = LibarayDbcontextSeeding.BookSeeding(dbConext);
            //if (DataSeeding)
            //{
            //    Console.WriteLine("data seeding succes");
            //}
            //else
            //    Console.WriteLine("data seeding Failed");


            //using LibarayDbConext dbConext = new LibarayDbConext();

            //bool DataSeeding = LibarayDbcontextSeeding.MemberSeeding(dbConext);
            //if (DataSeeding)
            //{
            //    Console.WriteLine("data seeding succes");
            //}
            //else
            //    Console.WriteLine("data seeding Failed"); 
            #endregion
            #region Test Method BorrowBook
            //using LibarayDbConext dbConext = new LibarayDbConext();
            //var Borrow = BorrowBook.BorrowBooks(dbConext, 1, 1);
            //if (Borrow)
            //{
            //    Console.WriteLine("Succes");
            //}
            //else
            //{
            //    Console.WriteLine("Failed");
            //} 
            #endregion
            #region Data Manipulation
            #region Q01
            //using LibarayDbConext dbConext = new LibarayDbConext();
            //var Book = dbConext.Books.Where(b => b.Price > 300).Select
            //    (b => new
            //    {
            //        booktitle = b.Title,
            //        categorytitle = b.Title,
            //        fullnameAuthor = b.author.FirstName + " " + b.author.LastName
            //    });
            //foreach (var book in Book)
            //{
            //    Console.WriteLine(book);
            //} 
            #endregion
            #region Q02
            //using LibarayDbConext dbConext = new LibarayDbConext();

            //var author = dbConext.Authors.Join(dbConext.Books,
            //    a => a.Id, b => b.AuthorId, (a, b) => new
            //    {
            //        Authorfullname = a.FirstName+ "" + a.LastName,
            //        bookid = b.Id,
            //        booktitle = b.Title
            //    });

            //foreach(var item in author)
            //{
            //    Console.WriteLine(item);
            //}

            #endregion


            #endregion
        }
        #region Q03
        public static bool BorrowBooks(LibarayDbConext dbConext, int BookId, int MemberId)
        {
            try
            {
                var memberloan = new MemberLoans
                {
                    MemberId = MemberId,
                    BookId = BookId,
                    DueDate = DateTime.Now.AddDays(5),
                };
                dbConext.MemberLoans.Add(memberloan);
                return dbConext.SaveChanges() > 0;
            }
            catch
            {
                return false;
            }
        }
        #endregion
        #region Q05
        public static List<Member> members(LibarayDbConext dbConext)
        {
            try
            {
                return dbConext.MemberLoans.Where
                    (m => m.ReturnDate == null ).Select
                    (m => m.member).ToList();
            }
            catch
            {
                return new List<Member>();
            }
        }
        #endregion
    }
}
