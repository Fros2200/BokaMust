using System.ComponentModel.DataAnnotations;

namespace BokaMust.Models
{
    public class Apple
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public string HarvestMonth { get; private set; }
        public string ImageFileName { get; private set; }

        public Apple(string name, string description, string harvestMonth, string imageFileName)
        {
            Name = name;
            Description = description;
            HarvestMonth = harvestMonth;
            ImageFileName = imageFileName;
               
        }
    }




}
