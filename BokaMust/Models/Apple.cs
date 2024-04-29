using System.ComponentModel.DataAnnotations;

namespace BokaMust.Models
{
    public class Apple
    {
        public string Name { get; set; }
        public string WeightInput { get; set; }
        public int Weight
        {
            get
            {
                // Försök konvertera inmatat värde till ett heltal, returnera 0 om konverteringen misslyckas
                int weight;
                return int.TryParse(WeightInput, out weight) ? weight : 0;
            }
        }
        [Range(30, 500, ErrorMessage = "Vikt måste vara mellan 30 och 500")]

        public AppleDescription Description { get; set; }
        public AppleHarvestMonth HarvestMonth { get; set; }

    }


    public enum AppleDescription
    {
        Söt,
        Frisk, 
        Syrlig,
        Smakrik, 
    }

    public enum AppleHarvestMonth
    {
        Augusti,
        September,
        Oktober,
        November,
    }

    public static class AppleRepository
    {
        public static List<Apple> AllApples { get; set; } = new List<Apple>
        {
            new Apple { Name = "Aroma", Description = AppleDescription.Syrlig, HarvestMonth = AppleHarvestMonth.September },
            new Apple { Name = "Cox Orange", Description = AppleDescription.Smakrik, HarvestMonth = AppleHarvestMonth.Oktober },
            new Apple { Name = "Discovery", Description = AppleDescription.Smakrik, HarvestMonth = AppleHarvestMonth.Augusti },
            new Apple { Name = "Frida", Description = AppleDescription.Syrlig, HarvestMonth = AppleHarvestMonth.November },
            new Apple { Name = "Gravenstiener", Description = AppleDescription.Syrlig, HarvestMonth = AppleHarvestMonth.September },
            new Apple { Name = "Ingrid-Marie", Description = AppleDescription.Frisk, HarvestMonth = AppleHarvestMonth.Oktober },
            new Apple { Name = "Rubinola", Description = AppleDescription.Söt, HarvestMonth = AppleHarvestMonth.Oktober },
            new Apple { Name = "Signe Tilisch", Description = AppleDescription.Söt, HarvestMonth = AppleHarvestMonth.Oktober },
            new Apple { Name = "Transparante Blanche", Description = AppleDescription.Syrlig, HarvestMonth = AppleHarvestMonth.Augusti },
            new Apple { Name = "Åkerö", Description = AppleDescription.Söt, HarvestMonth = AppleHarvestMonth.November },

        };
    }
}
