using Football_Team_Generator.Common;

namespace Football_Team_Generator.Models
{
    internal class Team
    {
        private string name;

        public Team(string name)
        {
           this.Name = name;
            this.Teams = new Dictionary<string, int>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new InvalidOperationException(GlobalConstants.InvalidName);
                }
            }
        }
        public Player Player { get; set; }

        public Dictionary<string, int> Teams { get; set; }

        public int Rating { get; set; }

        public void Add(string name , Player player)
        {
            if (!this.Teams.ContainsKey(name))
            {
                this.Teams.Add(name, player.OverallSkill);
            }

            else
            {
                this.Teams[name] += player.OverallSkill;
            }
        }

        public void Remove(string name, Player player)
        {

        }

    }
}
