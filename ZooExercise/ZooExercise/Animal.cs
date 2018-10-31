using System;

namespace ZooExercise
{
    public abstract class Animal
    {
        public string animalType { get; set; } // e.g. Lion, Tiger, Giraffe
        public string name { get; set; }
        public double weight { get; set; }

        // Each animal eats an amount of food that depends on its weight
        public abstract double CalculateAmountOfFoodNeeded(RateInfo rateInfo);  
    }
}
