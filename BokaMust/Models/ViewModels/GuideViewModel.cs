namespace BokaMust.Models.ViewModels
{
    public class GuideViewModel
    {
        public int Price { get; set; }
        public Apple SelectedApple { get; set; }
        public Packaging SelectedPackage { get; set; }

        public GuideViewModel()
        {
            SelectedApple = new Apple();
            SelectedPackage = new Packaging();
            Price = CalculatePrice(SelectedApple, SelectedPackage); 
        }

        

        public int CalculatePrice(Apple selectedApple, Packaging selectedPackage)
        {
            if (SelectedApple != null && SelectedPackage != null)
            {
                int weight = SelectedApple.Weight;
                var cost = SelectedPackage.Cost;
                return 0; 
            }
            return 0; 
        }
        
    }

}
