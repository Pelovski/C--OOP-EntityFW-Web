using P01._Advertisement_Message;

internal class Program
{
    private static void Main(string[] args)
    {

        int n = int.Parse(Console.ReadLine());


        var articles = new List<Article>();


        for (int i = 0; i < n; i++)
        {
            string[] input = Console.ReadLine()
          .Split(", ", StringSplitOptions.RemoveEmptyEntries);

            string title = input[0];
            string content = input[1];
            string author = input[2];

            var article = new Article(title, content, author);
            articles.Add(article);
        }

        string criteria = Console.ReadLine();
        articles = SortArticlesByGivenCriteria(articles, criteria);

        foreach (var article in articles)
        {
            Console.WriteLine(article.ToString());
        }
    }

    private static List<Article> SortArticlesByGivenCriteria(List<Article> articles, string criteria)
    {
        if (criteria == "title")
        {
            articles = articles.OrderBy(x => x.Title).ToList();
        }
        else if (criteria == "content")
        {
            articles = articles.OrderBy(x => x.Content).ToList();
        }

        else
        {
            articles = articles.OrderBy(x => x.Author).ToList();
        }

        return articles;
    }
}