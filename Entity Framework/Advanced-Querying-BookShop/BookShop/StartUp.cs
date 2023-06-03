namespace BookShop
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Cryptography.X509Certificates;
    using System.Text;
    using BookShop.Models.Enums;
    using Data;
    using Initializer;
    using Microsoft.EntityFrameworkCore;

    public class StartUp
    {
        public static void Main()
        {
            using var db = new BookShopContext();
            //DbInitializer.ResetDatabase(db);

            //var input = int.Parse(Console.ReadLine());

            var result = GetMostRecentBooks(db);

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

            var books = context
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

            var caterogies = input
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(c => c.ToLower())
                .ToList();

            var bookTitles = new List<string>();

            foreach (var categorie in caterogies)
            {
                var currenBookTitles = context
                    .Books
                    .Where(b => b.BookCategories
                    .Any(bc => bc.Category.Name == categorie))
                    .Select(b => b.Title)
                    .ToList();

                bookTitles.AddRange(currenBookTitles);
            }

            bookTitles = bookTitles
                .OrderBy(x => x)
                .ToList();

            return String.Join(Environment.NewLine, bookTitles);
        }

        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            var sb = new StringBuilder();

            var books = context
                .Books
                .ToList()
                .Where(b => b.ReleaseDate.Value.Date < DateTime.Parse(date))
                .Select(b => new
                {
                    b.Title,
                    b.EditionType,
                    b.Price,
                    b.ReleaseDate
                })
                .OrderByDescending(x => x.ReleaseDate)
                .ToList();

            foreach (var book in books)
            {
                sb.AppendLine($"{book.Title} - {book.EditionType} - ${book.Price:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            var sb = new StringBuilder();

            var authorsNames = context
                .Authors
                .Where(a => a.FirstName.ToLower().EndsWith(input.ToLower()))
                .Select(a => new
                {
                    a.FirstName,
                    a.LastName
                })
                .OrderBy(x => x.FirstName)
                .ThenBy(x => x.LastName)
                .ToList();

            foreach (var authorsName in authorsNames)
            {
                sb.AppendLine($"{authorsName.FirstName} {authorsName.LastName}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {

            var books = context
                .Books
                .Where(b => b.Title.ToLower().Contains(input.ToLower()))
                .Select(b => b.Title)
                .OrderBy(x => x)
                .ToList();


            return String.Join(Environment.NewLine, books);
        }

        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            var sb = new StringBuilder();

            var booksAuthors = context
                .Books
                .Where(b => b.Author.LastName.ToLower().StartsWith(input.ToLower()))
                .Select(b => new
                {
                    b.BookId,
                    b.Title,
                    b.Author
                })
                .OrderBy(x => x.BookId)
                .ToList();

            foreach (var booksAuthor in booksAuthors)
            {
                sb.AppendLine($"{booksAuthor.Title} ({booksAuthor.Author.FirstName} {booksAuthor.Author.LastName})");
            }

            return sb.ToString().TrimEnd();
        }

        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            var booksCount = context
                .Books
                .Where(b => b.Title.Length > lengthCheck)
                .Select(b => b.Title)
                .ToList();

            return booksCount.Count;
        }

        public static string CountCopiesByAuthor(BookShopContext context)
        {
            var sb = new StringBuilder();

            var booksCopies = context
                .Authors
                .Select(b => new
                {
                    FullName = b.FirstName + " " + b.LastName,
                    TotalCopies = b.Books
                                    .Select(b => b.Copies)
                                    .Sum()
                })
                .OrderByDescending(x => x.TotalCopies)
                .ToList();

            foreach (var booksCopie in booksCopies)
            {
                sb.AppendLine($"{booksCopie.FullName} - {booksCopie.TotalCopies}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            var sb = new StringBuilder();

            var booksProfit = context
                .Categories
                .Select(c => new
                {
                    c.Name,
                    TotalProfit = c.CategoryBooks
                                        .Select(cb => cb.Book.Copies * cb.Book.Price)
                                        .Sum()
                })
                .OrderByDescending(x => x.TotalProfit)
                .ThenBy(x => x.Name)
                .ToList();       

            foreach (var bp in booksProfit)
            {
                sb.AppendLine($"{bp.Name} ${bp.TotalProfit:f2}");    
            }  

            return sb.ToString().TrimEnd();
        }

        public static string GetMostRecentBooks(BookShopContext context)
        {
            var sb = new StringBuilder();

            var categories = context
                .Categories
                .Select(c => new
                {
                    c.Name,
                    RecentBooks = c.CategoryBooks
                                    .Select(cb => new
                                    {
                                      BookTitle = cb.Book.Title + " (" + cb.Book.ReleaseDate.Value.Year + ")",
                                      Date = cb.Book.ReleaseDate
                                    })
                                    .OrderByDescending(x => x.Date)
                                    .Take(3)
                })
                .OrderBy(x => x.Name)
                .ToList();

            foreach (var category in categories)
            {
                sb.AppendLine($"--{category.Name}");

                foreach (var books in category.RecentBooks)
                {
                    sb.AppendLine($"{books.BookTitle}");
                }
            }

            return sb.ToString().TrimEnd();
        }

        public static void IncreasePrices(BookShopContext context)
        {
            var books = context
                .Books
                .Where(b => b.ReleaseDate!= null && b.ReleaseDate.Value.Year < 2010)
                .ToArray();

            foreach (var book in books)
            {
                book.Price += 5;
            }

            context.SaveChanges();
        }

        public static int RemoveBooks(BookShopContext context)
        {
            var books = context
                .Books
                .Where(b => b.Copies < 4200)
                .ToList();

            var removedBooks = books.Count();

            context.RemoveRange(books);

            context.SaveChanges();

            return removedBooks;
        }
    }
}
