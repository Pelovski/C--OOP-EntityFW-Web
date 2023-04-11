using System.Reflection.Metadata.Ecma335;

namespace P03._Raiding.Models
{
    public abstract class BaseHero
    {

        public BaseHero(string name)
        {
            this.Name = name;
        }

        public string Name { get; }

        public int Power { get; set; }

        public abstract string CastAbility();
    }
}
