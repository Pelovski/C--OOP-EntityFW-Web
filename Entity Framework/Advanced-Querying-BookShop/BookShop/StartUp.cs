namespace BookShop
{
    using System;
    using System.Linq;
    using System.Text;
    using BookShop.Models.Enums;
    using Data;
    using Initializer;

    public class StartUp
    {
        public static void Main()
        {
            using var db = new BookShopContext();
            //DbInitializer.ResetDatabase(db);

            string result = GetGoldenBooks(db);

            Console.WriteLine(result);
        }

        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            var sb = new StringBuilder();

            var books = context
                 .Books
                 .ToList()
                 .Where(x => x.AgeRestriction.ToString().ToLower() == command.ToLower())
                 .Select(b => b.Title)
                 .OrderBy(bt => bt);

            foreach (var book in books)
            {
                sb.AppendLine(book);
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetGoldenBooks(BookShopContext context)
        {
            var sb = new StringBuilder();

            var goldenBooks = context
                .Books
                .ToList()
                .Where(b => b.EditionType.ToString() == "Gold" && b.Copies < 5000)
                .Select(b => new { 
                    b.AuthorId,
                    b.Title
                })
                .OrderBy(x => x.AuthorId);

            foreach (var book in goldenBooks)
            {
                sb.AppendLine(book.Title);
            }

            return sb.ToString().TrimEnd();
        }
    }
}
