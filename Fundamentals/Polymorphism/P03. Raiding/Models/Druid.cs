

using P03._Raiding.Comman;

namespace P03._Raiding.Models
{
    public class Druid : BaseHero
    {
        public Druid(string name) 
            : base(name)
        {
            this.Power = 80;
        }

        public override string CastAbility()
        {
            return $"{this.GetType().Name} – {this.Name} healed for {this.Power}";
        }
    }
}
