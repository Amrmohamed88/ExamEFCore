using ExamEFCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ExamEFCore.LibarayDbContext
{
    public class LibarayDbcontextSeeding
    {
        #region DataSeedingAuthor
        public static bool AuthorSeeding(LibarayDbConext dbConext)
        {
            try
            {
                if (dbConext.Authors.Any()) return false;
                var AuthorSeed = File.ReadAllText("Files\\Authors.json");
                if (string.IsNullOrEmpty(AuthorSeed))
                    return false;

                var Author = JsonSerializer.Deserialize<List<Author>>
                    (AuthorSeed, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                if (Author == null || Author.Count == 0)
                    return false;
                dbConext.Authors.AddRange(Author);
                return dbConext.SaveChanges() > 0;
            }
            catch
            {
                return false;
            }
        }
        #endregion
        #region CategoryDataSeeding
        public static bool CategorySeeding(LibarayDbConext dbConext)
        {
            try
            {
                if (dbConext.categories.Any()) return false;
                var Seeding = File.ReadAllText("Files\\Categories.json");

                if(string.IsNullOrEmpty(Seeding)) return false;
                var Category = JsonSerializer.Deserialize<List<Category>> (Seeding,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true});

                if (Category == null || Category.Count == 0)
                    return false;
                dbConext.categories.AddRange(Category);
                return dbConext.SaveChanges() > 0;
            }
            catch
            {
                return false;
            }
        }
        #endregion
        #region BookDataSeeding
        public static bool BookSeeding (LibarayDbConext dbConext)
        {
            try
            {
                if(dbConext.Books.Any()) return false;
                var Seeding = File.ReadAllText("Files\\Books.json");

                if(string.IsNullOrEmpty(Seeding)) return false;
                var Book = JsonSerializer.Deserialize<List<Book>>(Seeding,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                if (Book == null || Book.Count == 0) 
                    return false;

                dbConext.Books.AddRange(Book);
                return dbConext.SaveChanges() > 0;
            }
            catch
            {
                return false;
            }
        }
        #endregion
        #region MemberDataSeeding
        public static bool MemberSeeding (LibarayDbConext dbConext)
        {
            try
            {
                if (dbConext.Members.Any()) return false;
                var Seeding = File.ReadAllText("Files\\Members.json");

                if (string.IsNullOrEmpty(Seeding))
                    return false;

                var Member = JsonSerializer.Deserialize<List<Member>>(Seeding,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                if (Member == null || Member.Count == 0)
                    return false;
                dbConext.Members.AddRange(Member);
                return dbConext.SaveChanges() > 0;
            }
            catch
            {
                return false;
            }
        }
        #endregion

    }
}
