using System.Net.Http.Headers;
using Football_Team_Generator.Common;

namespace Football_Team_Generator.Models
{
    public class Stats
    {
        private const int MIN_Value = 0;
        private const int MAX_Value = 100;

        private const double STATS_COUNT = 5.0;

        private int shooting;
        private int passing;
        private int dribble;
        private int sprint;
        private int endurance;

        public Stats(int endurance, int sprint, int dribble, int passing, int shooting)
        {
            this.Endurance = endurance;
            this.Sprint = sprint;
            this.Dribble = dribble;
            this.Passing = passing;
            this.Shooting = shooting;
        }

        public int Endurance
        {
            get
            {
                return this.endurance;
            }
            set
            {
                this.Validator(value, nameof(this.Endurance));
                this.endurance = value;
            }
        }

        public int Sprint
        {
            get
            {
                return this.sprint;
            }
            set
            {

                this.Validator(value, nameof(this.Sprint));
                this.sprint = value;
            }
        }

        public int Dribble
        {
            get
            {
                return this.dribble;
            }
            set
            {
                this.Validator(value, nameof(this.Dribble));
                this.dribble = value;
            }
        }

        public int Passing
        {
            get
            {

                return this.passing;
            }
            set
            {
                this.Validator(value, nameof(this.Passing));
                this.passing = value;
            }
        }

        public int Shooting
        {
            get {
                return this.shooting;
            }
            set
            {
                this.Validator(value, nameof(this.Shooting));
                this.shooting = value;
            }
        }

        public double AverageStats =>
               (this.Endurance + this.Dribble + this.Sprint + this.Shooting + this.Passing) / STATS_COUNT;
   

        private void Validator(int value, string statName)
        {
            if (value < MIN_Value || value > MAX_Value)
            {
                throw new ArgumentException(String
                    .Format(GlobalConstants
                    .InvalidName, statName, MIN_Value, MAX_Value));
            }
        }
    }
}
