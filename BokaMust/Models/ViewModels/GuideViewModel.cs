namespace BokaMust.Models.ViewModels
{
    public class GuideViewModel
    {     
        public int Price { get; set; }
        public Apple SelectedApple { get; set; }
        public Package SelectedPackage { get; set; }

        public GuideViewModel()
        {
            SelectedApple = new Apple();
            SelectedPackage = new Package();
        }

        public int CalculatePrice()
        {
            if (SelectedApple != null && SelectedPackage != null)
            {
                int weight = SelectedApple.Weight;
                int cost = SelectedPackage.Cost;
                return weight * cost;
            }
            return 0; 
        }
        
    }

}
