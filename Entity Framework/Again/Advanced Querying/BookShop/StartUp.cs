namespace BookShop
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Text;
    using Data;

    public class StartUp
    {
        public static void Main()
        {
            using var db = new BookShopContext();

            //DbInitializer.ResetDatabase(db);

            //int year = int.Parse(Console.ReadLine());

             var result = GetBookTitlesContaining(db, "WOR");

            Console.WriteLine(result);
        }

        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            var sb =  new StringBuilder();


            var books = context
                .Books
                .AsEnumerable()
                .Where(b => b.AgeRestriction.ToString().ToLower() == command)
                .Select(b => new
                {
                    b.Title
                })
                .OrderBy(b => b.Title)
                .ToList();


            foreach (var book in books)
            {
                sb.AppendLine(book.Title);
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetGoldenBooks(BookShopContext context)
        {
            var sb =  new StringBuilder();

            var books = context
                .Books
                .AsEnumerable()
                .Where(b => b.EditionType.ToString().ToLower() == "gold" && b.Copies < 5000)
                .Select(b => new
                {
                  b.BookId,
                  b.Title
                })
                .OrderBy (b => b.BookId)
                .ToList();

            foreach(var book in books)
            {
                sb.AppendLine(book.Title);
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetBooksByPrice(BookShopContext context)

        
        {
            var sb = new StringBuilder();

            var books = context
                .Books
                .Where(b => b.Price > 40)
                .Select(b => new
                {
                    b.Title,
                    b.Price
                })
                .OrderByDescending(b => b.Price)
                .ToList();

            foreach (var book in books)
            {
                sb.AppendLine($"{book.Title} - ${book.Price:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            var sb = new StringBuilder();

            var books =  context
                .Books
                .Where(b => b.ReleaseDate.Value.Year != year)
                .Select(b => new
                {
                    b.BookId,
                    b.Title
                })
                .OrderBy(b => b.BookId)
                .ToList();

            foreach (var book in books)
            {
                sb.AppendLine(book.Title);
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            var sb = new StringBuilder();

            var categories = input.ToLower().Split(' ');
            
            var books = context
                .Books
                .Select(b => new {
                
                    b.Title,
                    BookCategories = 
                    b.BookCategories.Select(bc => new
                    {
                        bc.Category.Name
                    })
                })
                .ToList();

   
            var orderedBooks = new List<string>();

            foreach (var category in categories)
            {
                foreach (var book in books
                    .Where(b => b.BookCategories.Any(bc => bc.Name.ToLower() == category)))
                {
                    orderedBooks.Add(book.Title);
                }
            }


            foreach (var book in orderedBooks.OrderBy(b => b))
            {
                sb.AppendLine(book);
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            var sb = new StringBuilder();

            var currentDate = DateTime.Parse(date);

            var currentBooks = context
                .Books
                .Select(b => new
                {
                    b.Title,
                    b.EditionType,
                    b.Price,
                    BookDate = DateTime.Parse(b.ReleaseDate.Value.ToString("dd-MM-yyyy"))
                })
                .ToList();


            var books = currentBooks
            .Where(b => b.BookDate.Date < currentDate)
            .OrderByDescending(b => b.BookDate.Date)
            .ToList();

            foreach (var book in books)
            {
                sb.AppendLine($"{book.Title} - {book.EditionType} - ${book.Price:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            var sb = new StringBuilder();

            var books = context
                .Books
                .Where(b => b.Title.ToLower().Contains(input))
                .Select(b => b.Title) 
                .OrderBy(b => b)
                .ToList();

            foreach (var book in books)
            {
                sb.AppendLine(book);
            }

            return sb.ToString().TrimEnd();
        }
    }
}
