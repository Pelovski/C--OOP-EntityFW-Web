using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P03._Raiding.Comman;

namespace P03._Raiding.Models
{
    internal class Warrior : BaseHero
    {
        public Warrior(string name)
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
