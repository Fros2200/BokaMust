
namespace BokaMust.Models
{
    public class Packaging
    {
        public string Name { get; set; }
        public int Cost { get; set; }
    }

    public static class PackagingRepository
    {
        public static List<Packaging> AllPackages { get; } = new List<Packaging>
        {
            new Packaging { Name = "Råmust", Cost = 18 },
            new Packaging { Name = "BagInBox", Cost = 28 }
        };
    }
}