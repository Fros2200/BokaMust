
namespace BokaMust.Models
{
    public class Package
    {
        public string Name { get; private set; }
        public double Cost { get; private set; }

        public Package(string name, double cost)
        {
            Name = name;
            Cost = cost;
        }
    }

}