using static ZooExercise.FoodAvailable;

namespace ZooExercise
{
    public class Carnivore : Animal
    {
        public static readonly string foodType = Food.Meat.ToString();

        public Carnivore()
        {

        }
        public Carnivore(string animalType, string name, double weight)
        {
            this.animalType = animalType;
            this.name = name;
            this.weight = weight;
        }
        public override double CalculateAmountOfFoodNeeded(RateInfo rateInfo)
        {
            return weight * rateInfo.rate; 
        }
    }
}
