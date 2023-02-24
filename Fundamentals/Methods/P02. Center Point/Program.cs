internal class Program
{
    private static void Main(string[] args)
    {
        int number = int.Parse(Console.ReadLine());
        Tribonacci(number);
    }

    private static void Tribonacci(int number)
    {
        int[] arr = new int[number];

        arr[0] = 1;
        arr[1] = 1;
        arr[2] = 2;

        for (int i = 3; i < number; i++)
        {
            arr[i] = arr[i - 3] + arr[i - 2] + arr[i - 1];
        }

        Console.WriteLine(string.Join(" ", arr));
    }
}