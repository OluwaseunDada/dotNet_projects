
namespace ZooExercise
{
    public class RateInfo
    {
        public RateInfo()
        {           
        }

        public RateInfo(double rate, string foodType, double percentage)
        {
            this.rate = rate;
            this.percentage = percentage;
            this.foodType = foodType;
        }

       
        public double rate { get; set; }
        public double percentage { get; set; }
        public string foodType { get; set; }

    }
}
