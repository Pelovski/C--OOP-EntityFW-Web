using Football_Team_Generator.Common;

namespace Football_Team_Generator.Models
{
    public class Player
    {
        private const double STATS_COUNT = 5.0;
        private string name;

        public Player(string name, Stat stats)
        {
            this.Name = name;
            this.Stats = stats;
        }

        public string Name {
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

        public Stat Stats { get; set; }

        public int OverallSkill {
            get { return (int)Math
                    .Ceiling((this.Stats.Endurance + this.Stats.Dribble + this.Stats.Sprint + this.Stats.Shooting + this.Stats.Passing) / STATS_COUNT); }
        }

    }
}
