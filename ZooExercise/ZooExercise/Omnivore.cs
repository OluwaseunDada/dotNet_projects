using static ZooExercise.FoodAvailable;

namespace ZooExercise
{
    public class Omnivore : Animal
    {
        public static readonly string foodType = Food.Both.ToString();

        public Omnivore()
        {

        }
        public Omnivore(string animalType, string name, double weight)
        {
            this.animalType = animalType;
            this.name = name;
            this.weight = weight;
        }

        // amount of food needed depends on the weight. 
        // the rate determines how much food is needed. For omnivores, the rate must be split into meat and fruit
        public override double CalculateAmountOfFoodNeeded(RateInfo rateInfo)
        {
            double amountOfFoodNeeded = 0.0;
            
            // meat
            if (rateInfo.foodType.Equals(Food.Meat.ToString()))
            {
                amountOfFoodNeeded = weight * rateInfo.percentage * rateInfo.rate;
            }

            // fruit
            if (rateInfo.foodType.Equals(Food.Fruit.ToString()))
            {
                amountOfFoodNeeded = weight * (1 - rateInfo.percentage) * rateInfo.rate;
            }
           
            return amountOfFoodNeeded;
        }
    }
}
