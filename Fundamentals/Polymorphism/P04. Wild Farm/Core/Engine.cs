using P04._Wild_Farm.Models.Animals;
using P04._Wild_Farm.Models.Felines;
using P04._Wild_Farm.Models.Foods;
using P04._Wild_Farm.Models.Mamals;

namespace P04._Wild_Farm.Core
{
    public class Engine
    {
        public void Run()
        {
            List<Animal> animals = new List<Animal>();

            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                try
                {
                    string[] animalsInput = input
                    .Split();

                    string animalType = animalsInput[0];
                    string name = animalsInput[1];
                    double weight = double.Parse(animalsInput[2]);

                    var animal = CreateAnimal(animalsInput, animalType, name, weight);
                    animals.Add(animal);

                    Console.WriteLine(animal.ProducingSound());

                    string[] foodTypes = Console.ReadLine()
                        .Split();

                    string foodType = foodTypes[0];
                    int quantity = int.Parse(foodTypes[1]);

                    var food = CreateFood(foodType, quantity);

                    animal.Eat(foodType, quantity);

                    
                }
                catch (ArgumentException ae)
                {

                    Console.WriteLine(ae.Message);
                }

            }

            foreach (var animal in animals)
            {
                Console.WriteLine(animal.ToString());
            }
        }

        private static Food CreateFood(string foodType, int quantity)
        {
            Food food;

            if (foodType == "Vegetable")
            {
                food = new Vegetable(quantity);
            }
            else if (foodType == "Fruit")
            {
                food = new Fruit(quantity);
            }
            else if (foodType == "Meat")
            {
                food = new Fruit(quantity);
            }
            else
            {
                food = new Seeds(quantity);
            }

            return food;
        }

        private static Animal CreateAnimal(string[] animalsInput, string animalType, string name, double weight)
        {
            Animal animal;

            if (animalType == "Owl" || animalType == "Hen")
            {
                double wingSize = double.Parse(animalsInput[3]);

                animal = animalType == "Owl" ? animal = new Owl(name, weight, wingSize) :
                     new Hen(name, weight, wingSize);
            }

            else if (animalType == "Cat" || animalType == "Tiger")
            {
                string livingRegion = animalsInput[3];
                string breed = animalsInput[4];

                animal = animalType == "Cat" ? animal = new Cat(name, weight, livingRegion, breed) :
                   new Tiger(name, weight, livingRegion, breed);
            }

            else 
            {
                string livingRegion = animalsInput[3];

                animal = animalType == "Dog" ? animal = new Dog(name, weight, livingRegion) :
                   new Mouse(name, weight, livingRegion);
            }

            return animal;
        }
    }
}
