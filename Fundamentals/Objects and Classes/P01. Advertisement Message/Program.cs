using P01._Advertisement_Message;

internal class Program
{
    private static void Main(string[] args)
    {
        string[] input = Console.ReadLine()
            .Split(", ", StringSplitOptions.RemoveEmptyEntries);

        int n = int.Parse(Console.ReadLine());

        string title = input[0];
        string content = input[1];
        string author = input[2];

        var article = new Article(title, content, author);

        for (int i = 0; i < n; i++)
        {
            string[] command = Console.ReadLine()
                .Split(": ");

            if (command[0] == "Edit")
            {
                article.EditContent(command[1]);
            }
            else if(command[0] == "ChangeAuthor")
            {
                article.ChangeAuthor(command[1]);
            }

            else if (command[0] == "Rename")
            {
                article.Rename(command[1]);
            }
        }

        Console.WriteLine(article.ToString());
    }
}