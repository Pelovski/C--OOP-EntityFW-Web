using System.Security.Cryptography.X509Certificates;

class Program
{
    private static void Main(string[] args)
    {
        int[] input = Console.ReadLine()
            .Split(' ')
            .Select(int.Parse)
            .ToArray();

        int firstHashCount = input[0];
        int secondHashCount = input[1];

        var firstCollection = new HashSet<string>();
        var secondCollection = new HashSet<string>();

        AddToCollection(firstCollection, firstHashCount);
        AddToCollection(secondCollection, secondHashCount);

        var result = new HashSet<string>(firstCollection);

        result.IntersectWith(secondCollection);

        foreach (var item in result)
        {
            Console.WriteLine(item);
        }

    }

    public static HashSet<string> AddToCollection(HashSet<string> collection, int countIteration)
    {
        for (int i = 0; i < countIteration; i++)
        {
           string input = Console.ReadLine(); ;
            collection.Add(input);
        }
        return collection;
    }

}