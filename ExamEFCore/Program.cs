using ExamEFCore.LibarayDbContext;

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


            using LibarayDbConext dbConext = new LibarayDbConext();

            bool DataSeeding = LibarayDbcontextSeeding.MemberSeeding(dbConext);
            if (DataSeeding)
            {
                Console.WriteLine("data seeding succes");
            }
            else
                Console.WriteLine("data seeding Failed"); 
            #endregion
        }
    }
}
