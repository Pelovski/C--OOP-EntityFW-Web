internal class Program
{
    private static void Main(string[] args)
    {
        string type = Console.ReadLine();

        switch (type)
        {
            case "int": int num = int.Parse(Console.ReadLine());
                DataTypes(num);
                break;
            case "double":
                double doubNum = double.Parse(Console.ReadLine());
                DataTypes(doubNum);
                break;
            case "string":
                string text = Console.ReadLine();
                DataTypes(text);
                break;
            default:
                break;
        }
        
    }

    public static void DataTypes(int number)
    {
        number *= 2;
        Console.WriteLine(number);
    }

    public static void DataTypes(double number)
    {
        number *= 1.5;
        Console.WriteLine(number);
    }

    public static void DataTypes(string text)
    {
  
        Console.WriteLine($"${text}$"); 
    }
}