using P05._Teamwork_projects;

internal class Program
{
    private static void Main(string[] args)
    {
        int teamsCount = int.Parse(Console.ReadLine());

        var teams = new List<Team>();

        for (int i = 0; i < teamsCount; i++)
        {
            string[] teamAndUserInput = Console.ReadLine()
                .Split("-", StringSplitOptions.RemoveEmptyEntries);

            string userName = teamAndUserInput[0];
            string teamName = teamAndUserInput[1];

            if (teams.Any(x => x.Name == teamName))
            {
                Console.WriteLine($"Team {teamName} was already created!");
                continue;
            }

            if (teams.Any(x => x.User.Name == userName))
            {
                Console.WriteLine($"{userName} cannot create another team!");
                continue;
            }

            var user = new User(userName);

            var team = new Team(teamName, user);

            teams.Add(team);

            Console.WriteLine(team.ToString());
        }

        AddMember(teams);

        foreach (var team in teams.OrderByDescending(x => x.Members.Count).ThenBy(x => x.Name))
        {
            if (team.Members.Count != 0)
            {
                Console.WriteLine(team.Name);
                Console.WriteLine($"- {team.User.Name}");
                foreach (var member in team.Members)
                {
                    Console.WriteLine($"-- {member.Name}");
                }
            }

            else
            {
                Console.WriteLine("Teams to disband:");
                Console.WriteLine(team.Name);
            }
        }
    }

    private static void AddMember(List<Team> teams)
    {
        while (true)
        {

            string[] input = Console.ReadLine()
                .Split("->", StringSplitOptions.RemoveEmptyEntries);


            if (input[0] == "end of assignment")
            {
                break;
            }

            string userName = input[0];
            string teamName = input[1];

            

            if (!teams.Any(x => x.Name == teamName))
            {
                Console.WriteLine($"Team {teamName} does not exist!");
                continue;

            }

            if (teams.Any(x => x.User.Name == userName))
            {
                Console.WriteLine($"Member {userName} cannot join team {teamName}!");

            }
            else
            {
                var team = teams.FirstOrDefault(x => x.Name == teamName);
                var member = new Member(userName);
                team.Members.Add(member);
            }

        }
    }
}