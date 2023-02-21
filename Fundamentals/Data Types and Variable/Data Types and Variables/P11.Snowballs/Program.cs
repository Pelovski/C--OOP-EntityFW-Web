internal class Program
{
    private static void Main(string[] args)
    {
        int numberOfSnowBalls = int.Parse(Console.ReadLine());
        double maxSnowBall = 0;
        int maxSnowBallNow = 0;
        int maxSnowTime = 0;
        int maxSnowBallQuantity = 0;

        for (int i = 0; i < numberOfSnowBalls; i++)
        {
            int snowBallsNow = int.Parse(Console.ReadLine());
            int snowTime = int.Parse(Console.ReadLine());
            int snowballQuality = int.Parse(Console.ReadLine());

            double currentMaxSnowBall =  Math.Pow((snowBallsNow / snowTime), snowballQuality);

            if (currentMaxSnowBall > maxSnowBall)
            {
                maxSnowBall = currentMaxSnowBall;

                maxSnowBallNow = snowBallsNow;
                maxSnowTime = snowTime;
                maxSnowBallQuantity = snowballQuality;
            }
        }

        Console.WriteLine($"{maxSnowBallNow} : {maxSnowTime} = {maxSnowBall} ({maxSnowBallQuantity})");

        
    }
}