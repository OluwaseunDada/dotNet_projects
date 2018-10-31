using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using static ZooExercise.FoodAvailable;

namespace ZooExercise
{
    public class ZooSpendingCalculator
    {

        private static double totalFeedingCost = 0;
        public static void Main(string[] args)
        {
            // The total feeding cost is calculated by summing up the feeding cost for each of the animals present in the zoo
            CalculateTotalFeedingCost();

            // Outputs the final calculation result to the console 
            Display();
        }

        /*
         * The total feeding cost is calculated by summing up the feeding cost for each of the animals present in the zoo
         * 
         * */
        public static double CalculateTotalFeedingCost()
        {
            ZooSpendingCalculator calculator = new ZooSpendingCalculator();

            List<ZooContentInfo> zooList = calculator.GetZooContent();

            Console.WriteLine("Animal\t\t" + " Name\t\t" + " Food\t" + " FoodPricePerKg\t" + " AmountOfFoodConsumed\t" + " Feeding Cost\t");

            // loop through all the animals present in the zoo
            foreach (var zooContentInfo in zooList)
            {
                Console.Write(zooContentInfo.animalType + "\t\t" + zooContentInfo.name + "\t" + "\n");

                // for each animal in the zoo, calculate the feeding cost
                totalFeedingCost = totalFeedingCost + calculator.CalculateAnimalFeedingCost(zooContentInfo);

            }

            return totalFeedingCost;
        }

        /*
         * Calculate the feeding cost as follows: 
         * feedingCost = foodPricePerKg * amountOfFoodNeeded
         * */
        public double CalculateAnimalFeedingCost (ZooContentInfo zooContentInfo)
        {
            RateInfo rateInfo = GetRateInfoForAnimal(zooContentInfo.animalType);

            // foodPricePerKg
            var meatPricePerKg = Double.Parse(GetFoodPricePerKg(Food.Meat.ToString()), CultureInfo.InvariantCulture);
            var fruitPricePerKg = Double.Parse(GetFoodPricePerKg(Food.Fruit.ToString()), CultureInfo.InvariantCulture);

            // carnivore
            if (rateInfo.foodType.Equals(Carnivore.foodType.ToLower()))
            {
                Carnivore carnivore = new Carnivore(zooContentInfo.animalType, zooContentInfo.name, zooContentInfo.weight);
                var amountOfFoodNeeded = carnivore.CalculateAmountOfFoodNeeded(rateInfo);
                var feedingCost = meatPricePerKg * amountOfFoodNeeded;
                totalFeedingCost = totalFeedingCost + feedingCost;
                Console.Write("\t\t\t\t" + Carnivore.foodType + "\t\t" + meatPricePerKg + "\t\t" + amountOfFoodNeeded + "Kg" + "\t\t" + meatPricePerKg + " * " + amountOfFoodNeeded + " = " + feedingCost + "\t\t" + "\n");
                return feedingCost;
            }

            // herbivore
            if (rateInfo.foodType.Equals(Herbivore.foodType.ToLower()))
            {
                Herbivore herbivore = new Herbivore(zooContentInfo.animalType, zooContentInfo.name, zooContentInfo.weight);
                var amountOfFoodNeeded = herbivore.CalculateAmountOfFoodNeeded(rateInfo);
                var feedingCost = fruitPricePerKg * amountOfFoodNeeded;
                totalFeedingCost = totalFeedingCost + feedingCost;

                Console.Write("\t\t\t\t" + Herbivore.foodType + "\t\t" + fruitPricePerKg + "\t\t" + amountOfFoodNeeded + "Kg" + "\t\t" + fruitPricePerKg + " * " + amountOfFoodNeeded + " = " + feedingCost + "  " + "\t\t" + "\n");
                
                return feedingCost;
            }

            // omnivore
            if (rateInfo.foodType.Equals(Omnivore.foodType.ToLower()))
            {
                Omnivore omnivore = new Omnivore(zooContentInfo.animalType, zooContentInfo.name, zooContentInfo.weight);

                // meat
                rateInfo.foodType = Food.Meat.ToString();
                var amountOfMeatNeeded = omnivore.CalculateAmountOfFoodNeeded(rateInfo);
                var feedingCostMeat = meatPricePerKg * amountOfMeatNeeded;
                totalFeedingCost = totalFeedingCost + feedingCostMeat;

                Console.Write("\t\t\t\t" + Food.Meat.ToString() + "\t\t" + meatPricePerKg + "\t\t" + amountOfMeatNeeded + "Kg" + "\t\t" + meatPricePerKg + " * " + amountOfMeatNeeded + " = " + feedingCostMeat + "\t\t" + "\n");

                // fruit
                rateInfo.foodType = Food.Fruit.ToString();
                var amountOfFruitNeeded = omnivore.CalculateAmountOfFoodNeeded(rateInfo);
                var feedingCostFruit = fruitPricePerKg * amountOfFruitNeeded;
                //var feedingCost = feedingCostFruit + feedingCostMeat;
                totalFeedingCost = totalFeedingCost + feedingCostFruit;

                Console.Write("\t\t\t\t" + Food.Fruit.ToString() + "\t\t" + fruitPricePerKg + "\t\t" + amountOfFruitNeeded + "Kg" + "\t\t" + fruitPricePerKg + " * " + amountOfFruitNeeded + " = " + feedingCostFruit + "\t\t" + "\n");
                return feedingCostFruit + feedingCostMeat;
            }

            return 0.0;
        }

        /**
         * Extract information regarding food prices from prices.txt
         **/
        public string GetFoodPricePerKg(string foodType) 
        {
            var result = File.ReadLines("prices.txt").Select(line => line.Split('=')).ToDictionary(pair => pair[0], pair => pair[1]);
            return result[foodType];
        }

        /**
       * Extract information regarding the animal species present in the zoo from animal.csv
       **/
        public RateInfo GetRateInfoForAnimal(string animal)    
        {
            var result = File.ReadLines("animals.csv").Select(line => line.Split(';'));

            Dictionary<string, RateInfo> dictionary = new Dictionary<string, RateInfo>();
            foreach (string[] aText in result)
            {
                var rate = Double.Parse(aText[1], CultureInfo.InvariantCulture);

                double percentage = 0.0;
                if (aText[3] != "")
                {
                    percentage = (double.Parse(aText[3].TrimEnd(new char[] { '%', ' ' })))/100;
                }
                    

                RateInfo rateInfo = new RateInfo(rate, aText[2], percentage);
                dictionary.Add(aText[0], rateInfo);
            }

            return dictionary[animal];
        }

        /**
         * Extract information regarding the content of the zoo from zoo.xml
         **/
        public List<ZooContentInfo> GetZooContent()
        {
            XmlReader xmlReader = XmlReader.Create("zoo.xml");
            Dictionary<string, ZooContentInfo> dictionary = new Dictionary<string, ZooContentInfo>();
            ZooContentInfo zooContentInfo = new ZooContentInfo();
            List<ZooContentInfo> zooList = new List<ZooContentInfo>();

            while (xmlReader.Read())
            {
                if ((xmlReader.NodeType == XmlNodeType.Element))
                {
                    if (xmlReader.HasAttributes)
                    {
                        zooContentInfo = new ZooContentInfo(xmlReader.Name, xmlReader.GetAttribute("name"), Double.Parse(xmlReader.GetAttribute("kg"), CultureInfo.InvariantCulture));
                        zooList.Add(zooContentInfo);
                        //Console.WriteLine(xmlReader.Name + ": " + xmlReader.GetAttribute("name") + ": " + xmlReader.GetAttribute("kg"));
                    }
                }
            }

            return zooList;
        }

        /*
         * Outputs the final calculation result to the console 
         * */
        private static void Display()
        {
            Console.WriteLine("\n\t\t\t\t\t\t\t\t\t***********************************");
            Console.WriteLine("\t\t\t\t\t\t\t\t\t  Total Feeding cost = " + totalFeedingCost);
            Console.WriteLine("\t\t\t\t\t\t\t\t\t***********************************");

            Console.ReadLine();
        }
    }

    
}
