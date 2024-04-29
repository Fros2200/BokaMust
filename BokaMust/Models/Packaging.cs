
namespace BokaMust.Models
{
    public class Package
    {
        public string Name { get; set; }
        public int Cost { get; set; }
    }

    public static class PackagingRepository
    {
        public static List<Package> AllPackages { get; set; } = new List<Package>
        {
            new Package { Name = "Råmust", Cost = 18 },
            new Package { Name = "BagInBox", Cost = 28 }
        };
    }
}