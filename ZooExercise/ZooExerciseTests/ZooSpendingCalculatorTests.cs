using Microsoft.VisualStudio.TestTools.UnitTesting;
using ZooExercise;
using System;
using System.Collections.Generic;

namespace ZooExercise.Tests
{
    [TestClass()]
    public class ZooSpendingCalculatorTests
    {
        /*
         * Assumption: I am assuming that the data files are located in the default directory and the names are correct
         * */

        [TestMethod()]
        public void CalculateTotalFeedingCostTest()
        {
            double result = ZooSpendingCalculator.CalculateTotalFeedingCost();

            Assert.AreEqual(1609.00896, result, 0.000000001, "wrong calculation result");
        }

        [TestMethod()]
        public void CalculateAnimalFeedingCostTest()
        {
            ZooSpendingCalculator calculator = new ZooSpendingCalculator();

            List<ZooContentInfo> zooList = calculator.GetZooContent();

            double result = 0.0;

            Assert.IsNotNull(zooList, "zooList should not be null");
            Assert.AreEqual(14, zooList.Count, "zooList size should be 14");

            // Lion name='Simba'
            result = calculator.CalculateAnimalFeedingCost(zooList[0]);
            Assert.AreEqual(200.96, result, "wrong calculation result");

            //Lion name='Nala'
            result = calculator.CalculateAnimalFeedingCost(zooList[1]);
            Assert.AreEqual(216.032, result, "wrong calculation result");

            //Lion name='Mufasa'
            result = calculator.CalculateAnimalFeedingCost(zooList[2]);
            Assert.AreEqual(238.64, result, 0.000000001, "wrong calculation result");

            //Giraffe name = 'Hanna'
            result = calculator.CalculateAnimalFeedingCost(zooList[3]);
            Assert.AreEqual(89.6, result, "wrong calculation result");

            //Giraffe name = 'Anna'
            result = calculator.CalculateAnimalFeedingCost(zooList[4]);
            Assert.AreEqual(90.496, result, "wrong calculation result");

            //Giraffe name = 'Susanna'
            result = calculator.CalculateAnimalFeedingCost(zooList[5]);
            Assert.AreEqual(89.152, result, "wrong calculation result");

            //Tiger name = 'Dante'
            result = calculator.CalculateAnimalFeedingCost(zooList[6]);
            Assert.AreEqual(169.56, result, "wrong calculation result");

            //Tiger name = 'Asimov'
            result = calculator.CalculateAnimalFeedingCost(zooList[7]);
            Assert.AreEqual(160.5168, result, "wrong calculation result");

            //Tiger name = 'Tolkien'
            result = calculator.CalculateAnimalFeedingCost(zooList[8]);
            Assert.AreEqual(157.1256, result, "wrong calculation result");

            //Zebra name = 'Chip'
            result = calculator.CalculateAnimalFeedingCost(zooList[9]);
            Assert.AreEqual(44.8, result, "wrong calculation result");

            //Zebra name = 'Dale'
            result = calculator.CalculateAnimalFeedingCost(zooList[10]);
            Assert.AreEqual(27.776, result, "wrong calculation result");

            //Wolf name = 'Pin'
            result = calculator.CalculateAnimalFeedingCost(zooList[11]);
            Assert.AreEqual(61.71984 + 3.0576, 0.000000001, result, "wrong calculation result");

            //Wolf name = 'Pon'
            result = calculator.CalculateAnimalFeedingCost(zooList[12]);
            Assert.AreEqual(54.59832 + 2.7048, result, 0.000000001, "wrong calculation result");

            //Piranha name = 'Anastasia'
            result = calculator.CalculateAnimalFeedingCost(zooList[13]);
            Assert.AreEqual(1.57 + 0.7, result, "wrong calculation result");

        }

        [TestMethod()]
        public void GetFoodPricePerKgTest()
        {
            ZooSpendingCalculator calculator = new ZooSpendingCalculator();

            //Meat=12.56
            Assert.AreEqual("12.56", calculator.GetFoodPricePerKg("Meat"), "Wrong price for meat");

            //Fruit=5.60
            Assert.AreEqual("5.60", calculator.GetFoodPricePerKg("Fruit"), "Wrong price for fruit");
        }

        [TestMethod()]
        public void GetRateInfoForAnimalTest()
        {
            ZooSpendingCalculator calculator = new ZooSpendingCalculator();

            // Lion
            RateInfo rateInfoLion = calculator.GetRateInfoForAnimal("Lion");
            Assert.AreEqual(0.10, rateInfoLion.rate, "wrong rate value");
            Assert.AreEqual("meat", rateInfoLion.foodType, "wrong food type");
            Assert.AreEqual(0, rateInfoLion.percentage, "wrong percentage value");

            // Tiger
            RateInfo rateInfoTiger = calculator.GetRateInfoForAnimal("Tiger");
            Assert.AreEqual(0.09, rateInfoTiger.rate, "wrong rate value");
            Assert.AreEqual("meat", rateInfoTiger.foodType, "wrong food type");
            Assert.AreEqual(0, rateInfoLion.percentage, "wrong percentage value");

            // Giraffe
            RateInfo rateInfoGiraffe = calculator.GetRateInfoForAnimal("Giraffe");
            Assert.AreEqual(0.08, rateInfoGiraffe.rate, "wrong rate value");
            Assert.AreEqual("fruit", rateInfoGiraffe.foodType, "wrong food type");
            Assert.AreEqual(0, rateInfoLion.percentage, "wrong percentage value");

            // Zebra
            RateInfo rateInfoZebra = calculator.GetRateInfoForAnimal("Zebra");
            Assert.AreEqual(0.08, rateInfoZebra.rate, "wrong rate value");
            Assert.AreEqual("fruit", rateInfoZebra.foodType, "wrong food type");
            Assert.AreEqual(0, rateInfoLion.percentage, "wrong percentage value");

            // Wolf
            RateInfo rateInfoWolf = calculator.GetRateInfoForAnimal("Wolf");
            Assert.AreEqual(0.07, rateInfoWolf.rate, "wrong rate value");
            Assert.AreEqual("both", rateInfoWolf.foodType, "wrong food type");
            Assert.AreEqual(0.9, rateInfoWolf.percentage, 0, "wrong percentage value");

            // Piranha
            RateInfo rateInfoPiranha = calculator.GetRateInfoForAnimal("Piranha");
            Assert.AreEqual(0.5, rateInfoPiranha.rate, "wrong rate value");
            Assert.AreEqual("both", rateInfoPiranha.foodType, "wrong food type");
            Assert.AreEqual(0.5, rateInfoPiranha.percentage, 0, "wrong percentage value");
        }

        [TestMethod()]
        public void GetZooContentTest()
        {
            ZooSpendingCalculator calculator = new ZooSpendingCalculator();
            List<ZooContentInfo> list = calculator.GetZooContent();

            Assert.IsNotNull(list, "list should not be null");
            Assert.AreEqual(14, list.Count, "list size should be 14");

            // Lion
            Assert.AreEqual("Lion", list[0].animalType, "wrong animal type");
            Assert.AreEqual("Simba", list[0].name, "wrong name");
            Assert.AreEqual(160, list[0].weight, "incorrect value for weight");

            Assert.AreEqual("Lion", list[1].animalType, "wrong animal type");
            Assert.AreEqual("Nala", list[1].name, "wrong name");
            Assert.AreEqual(172, list[1].weight, "incorrect value for weight");

            Assert.AreEqual("Lion", list[2].animalType, "wrong animal type");
            Assert.AreEqual("Mufasa", list[2].name, "wrong name");
            Assert.AreEqual(190, list[2].weight, "incorrect value for weight");

            // Giraffe
            Assert.AreEqual("Giraffe", list[3].animalType, "wrong animal type");
            Assert.AreEqual("Hanna", list[3].name, "wrong name");
            Assert.AreEqual(200, list[3].weight, "incorrect value for weight");

            Assert.AreEqual("Giraffe", list[4].animalType, "wrong animal type");
            Assert.AreEqual("Anna", list[4].name, "wrong name");
            Assert.AreEqual(202, list[4].weight, "incorrect value for weight");

            Assert.AreEqual("Giraffe", list[5].animalType, "wrong animal type");
            Assert.AreEqual("Susanna", list[5].name, "wrong name");
            Assert.AreEqual(199, list[5].weight, "incorrect value for weight");

            // Tiger
            Assert.AreEqual("Tiger", list[6].animalType, "wrong animal type");
            Assert.AreEqual("Dante", list[6].name, "wrong name");
            Assert.AreEqual(150, list[6].weight, "incorrect value for weight");

            Assert.AreEqual("Tiger", list[7].animalType, "wrong animal type");
            Assert.AreEqual("Asimov", list[7].name, "wrong name");
            Assert.AreEqual(142, list[7].weight, "incorrect value for weight");

            Assert.AreEqual("Tiger", list[8].animalType, "wrong animal type");
            Assert.AreEqual("Tolkien", list[8].name, "wrong name");
            Assert.AreEqual(139, list[8].weight, "incorrect value for weight");

            // Zebra
            Assert.AreEqual("Zebra", list[9].animalType, "wrong animal type");
            Assert.AreEqual("Chip", list[9].name, "wrong name");
            Assert.AreEqual(100, list[9].weight, "incorrect value for weight");

            Assert.AreEqual("Zebra", list[10].animalType, "wrong animal type");
            Assert.AreEqual("Dale", list[10].name, "wrong name");
            Assert.AreEqual(62, list[10].weight, "incorrect value for weight");

            // Wolf
            Assert.AreEqual("Wolf", list[11].animalType, "wrong animal type");
            Assert.AreEqual("Pin", list[11].name, "wrong name");
            Assert.AreEqual(78, list[11].weight, "incorrect value for weight");

            Assert.AreEqual("Wolf", list[12].animalType, "wrong animal type");
            Assert.AreEqual("Pon", list[12].name, "wrong name");
            Assert.AreEqual(69, list[12].weight, "incorrect value for weight");

            // Piranha
            Assert.AreEqual("Piranha", list[13].animalType, "wrong animal type");
            Assert.AreEqual("Anastasia", list[13].name, "wrong name");
            Assert.AreEqual(0.5, list[13].weight, "incorrect value for weight");
        }

      
       
    }
}