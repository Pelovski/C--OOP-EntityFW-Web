using P04._Border_Control;

internal class StartUp
{
    private static void Main(string[] args)
    {

        var citizensData = new List<ICitizen>();
        var robotsData = new List<IRobot>();
        var detainedIds = new List<string>();

        while (true)
        {
            string[] input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            if (input[0] == "End")
            {
                break;
            }

            if (input.Length == 3)
            {
                string name = input[0];
                int age = int.Parse(input[1]);
                string id = input[2];

                var citizen = new Citizen(name, age, id);

                citizensData.Add(citizen);
            }

            else
            {
                string model = input[0];
                string id = input[1];

                var robot = new Robot(model, id);

                robotsData.Add(robot);
            }
        }

       string fakeId = Console.ReadLine();

        foreach (var citizen in citizensData)
        {
            if (citizen.Id.EndsWith(fakeId))
            {
                detainedIds.Add(citizen.Id);
            }
        }

        foreach (var robot in robotsData)
        {
            if (robot.Id.EndsWith(fakeId))
            {
                detainedIds.Add(robot.Id);
            }
        }

        Console.WriteLine(string.Join("\n", detainedIds));
    }
}