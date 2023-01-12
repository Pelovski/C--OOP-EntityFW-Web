 class Program
{
    private static void Main(string[] args)
    {
        int[] inputClothes = Console.ReadLine()
        .Split(new Char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
        .Select(item => int.Parse(item))
        .ToArray();

        int rackaCpacity = int.Parse(Console.ReadLine());
        var clothes = new Stack<int>(inputClothes);


        int colothesLength = clothes.Count;
        int racksCount = 1;
        int currentCapacity = rackaCpacity;

        for (int i = 0; i < colothesLength; i++)
        {
            int currentClothe = clothes.Pop();

            if (currentCapacity >= currentClothe)
            {
                currentCapacity -= currentClothe;
            }
            else
            {
                currentCapacity = rackaCpacity - currentClothe;
                racksCount++;
            }
        }

        Console.WriteLine(racksCount);


    }
}