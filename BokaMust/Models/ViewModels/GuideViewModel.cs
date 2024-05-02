using System.ComponentModel.DataAnnotations;

namespace BokaMust.Models.ViewModels
{
    public class GuideViewModel
    {
        public List<Apple> Apples { get; set; } = new List<Apple>();
        public List<Package> Packages { get; set; } = new List<Package>();

        [Required(ErrorMessage = "Välj en äppelsort")]
        public string SelectedApple { get; set; }
        [Required(ErrorMessage = "Välj en förpackningstyp")]
        public string SelectedPackage { get; set; }
        [Required]
        [Range(30, int.MaxValue, ErrorMessage ="Minsta vikt är 30kg")]
        public double Weight { get; set; }
        public double Price { get; set; }
        public double Volume { get; set; }
        public double NumberOfBib { get; set; }
        public double SessionTime { get; set; }


        public Apple GetSelectedApple() 
        {
            return Apples?.FirstOrDefault(a => a.Name == SelectedApple);
        }

        public Package GetSelectedPackage() 
        {
            return Packages?.FirstOrDefault(p => p.Name == SelectedPackage);
        }
    }
}
