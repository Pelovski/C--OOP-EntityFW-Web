using System.Net.Http.Headers;
using Football_Team_Generator.Common;

namespace Football_Team_Generator.Models
{
    public class Stat
    {
        private int shooting;
        private int passing;
        private int dribble;
        private int sprint;
        private int endurance;

        public Stat(int endurance, int sprint, int dribble, int passing, int shooting)
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
                return endurance;
            }
            set
            {
                if (Validator(value))
                {
                    throw new ArgumentException(GlobalConstants.InvalidStatsInput);
                }

                this.endurance = value;
            }
        }

        public int Sprint
        {
            get
            {
                return sprint;
            }
            set
            {
                if (Validator(value))
                {
                    throw new ArgumentException(GlobalConstants.InvalidStatsInput);
                }

                this.sprint = value;
            }
        }

        public int Dribble
        {
            get
            {
                return dribble;
            }
            set
            {
                if (Validator(value))
                {
                    throw new ArgumentException(GlobalConstants.InvalidStatsInput);
                }

                this.dribble = value;
            }
        }

        public int Passing
        {
            get
            {
                return passing;
            }
            set
            {
                if (Validator(value))
                {
                    throw new ArgumentException(GlobalConstants.InvalidStatsInput);
                }
                this.passing = value;
            }
        }

        public int Shooting
        {
            get {
                return shooting;
            }
            set
            {
                if (Validator(value))
                {
                    throw new ArgumentException(GlobalConstants.InvalidStatsInput);
                }

                this.shooting = value;
            }
        }

        private bool Validator(int stat)
        {
            return stat < 0 && stat > 100;
        }
    }
}
