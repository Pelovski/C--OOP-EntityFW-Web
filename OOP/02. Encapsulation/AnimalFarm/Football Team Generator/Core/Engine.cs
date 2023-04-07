using System.Globalization;
using System.Numerics;
using Football_Team_Generator.Common;
using Football_Team_Generator.Models;

namespace Football_Team_Generator.Core
{
    public class Engine
    {
        private List<Team> teams= new List<Team>();

        public Engine()
        {
            this.teams = new List<Team>();
        }

        public void Run()
        {
            string command;

            while ((command = Console.ReadLine()) != "END")
            {
                try
                {
                    string[] commandArgs = command
                    .Split(';', StringSplitOptions.RemoveEmptyEntries);

                    string cmdType = commandArgs[0];
                    string teamName = commandArgs[1];

                    if (cmdType == "Team")
                    {
                        AddTeam(teamName);

                    }
                    else if (cmdType == "Add")
                    {
                        AddPlayerToTeam(commandArgs, teamName);

                    }
                    else if (cmdType == "Remove")
                    {
                        RemovePlayerFromTeam(commandArgs, teamName);
                    }
                    else if (cmdType == "Rating")
                    {
                        PrintTeam(teamName);
                    }
                }

                catch (ArgumentException ae)
                {

                    Console.WriteLine(ae.Message);
                }
                catch(InvalidOperationException ioe)
                {
                    Console.WriteLine(ioe.Message);
                }
                
            }
        }

        private void PrintTeam(string teamName)
        {
            Validator(teamName);

            var team = this.teams.First(t => t.Name == teamName);

            Console.WriteLine(team);
        }

        private void RemovePlayerFromTeam(string[] commandArgs, string teamName)
        {
            string playerName = commandArgs[2];

            this.teams.First(t => t.Name == teamName).Remove(playerName);
        }

        private void AddPlayerToTeam(string[] commandArgs, string teamName)
        {
            Validator(teamName);

            string playerName = commandArgs[2];

            int endurance = int.Parse(commandArgs[3]);
            int sprint = int.Parse(commandArgs[4]);
            int dribble = int.Parse(commandArgs[5]);
            int passing = int.Parse(commandArgs[6]);
            int shooting = int.Parse(commandArgs[7]);

            var stats = new Stats(endurance, sprint, dribble, passing, shooting);
            var player = new Player(playerName, stats);

            this.teams.First(t => t.Name == teamName).Add(player);
        }

        private void AddTeam(string teamName)
        {
            var team = new Team(teamName);

            this.teams.Add(team);
        }

        private void Validator(string teamName)
        {
            if (!this.teams.Any(t => t.Name == teamName))
            {
                throw new ArgumentException(String.Format(GlobalConstants.AddPlayerToMissingTeam, teamName));
            }
        }
    }
}
