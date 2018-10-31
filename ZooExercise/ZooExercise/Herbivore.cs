using static ZooExercise.FoodAvailable;

namespace ZooExercise
{
    public class Herbivore : Animal
    {
        public static readonly string foodType = Food.Fruit.ToString();

        public Herbivore()
        {

        }
        public Herbivore(string animalType, string name, double weight)
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
