using System.Runtime.CompilerServices;
using P03._Raiding.Models;

namespace P03._Raiding.Core
{
    public static class Engine
    {
        public static void Run()
        {
            var heroes = new List<BaseHero>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string name = Console.ReadLine();
                string type = Console.ReadLine();

                try
                {
                    var hero = CreateHero(name, type);
                    heroes.Add(hero);

                    Console.WriteLine(hero.CastAbility());
                    
                }
                catch (ArgumentException ae)
                {

                    Console.WriteLine(ae.Message);
                }

            }

            int bossPower = int.Parse(Console.ReadLine());
            int heroesPower = heroes.Sum(x => x.Power);

            if (heroesPower > bossPower)
            {
                Console.WriteLine("Victory!");
            }
            else
            {
                Console.WriteLine("Defeat...");
            }
        }

        private static BaseHero CreateHero(string name, string type)
        {

            BaseHero baseHero;

            if (type == "Warrior")
            {
                baseHero = new Warrior(name);
            }
            else if (type == "Druid")
            {
                baseHero = new Druid(name);
            }
            else if (type == "Paladin")
            {
                baseHero = new Paladin(name);
            }
            else if (type == "Rogue")
            {
                baseHero = new Rogue(name);
            }
            else
            {
                throw new ArgumentException("Invalid hero!");
            }

            return baseHero;
        }

    }
}
