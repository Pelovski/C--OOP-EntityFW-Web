using Football_Team_Generator.Common;

namespace Football_Team_Generator.Models
{
    internal class Team
    {
        private List<Player> players;
        private string name;

        public Team(string name)
        {
           this.Name = name;
           this.players = new List<Player>();
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
                this.name = value;
            }
        }

        public int Rating
        {
            get
            {
                if (this.players.Count == 0)
                {
                    return 0;
                }

                return (int)Math.Round(this.players.Sum(p =>
                p.OverallSkill) / this.players.Count);
            }
        }

        public void Add(Player player)
        {

            this.players.Add(player);
        }

        public void Remove(string name)
        {
            var player = this.players.FirstOrDefault(p => p.Name == name);

            if (player == null)
            {
                throw new InvalidOperationException(String.Format(GlobalConstants.RemovePlayerdoesNotExist, name, this.Name));
            }

            this.players.Remove(player);
        }

        public override string ToString()
        {
            return $"{this.Name} - {this.Rating}";
        }

    }
}
