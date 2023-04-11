using P03._Raiding.Comman;

namespace P03._Raiding.Models
{
    public class Rogue : BaseHero
    {
        public Rogue(string name) 
            : base(name)
        {
            this.Power = 100;
        }
        public override string CastAbility()
        {
            return $"{this.GetType().Name} – {this.Name} hit for {this.Power} damage";
        }
    }
}
