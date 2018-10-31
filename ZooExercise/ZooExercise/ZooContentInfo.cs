
namespace ZooExercise
{
    public class ZooContentInfo
    {
        public ZooContentInfo()
        {           
        }
        public ZooContentInfo(string animalType, string name, double weight)
        {
            this.animalType = animalType;
            this.name = name;
            this.weight = weight;
        }

        public string animalType { get; set; }
        public string name  { get; set; }
        public double weight { get; set; } 
    }
}
