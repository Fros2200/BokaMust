using BokaMust.Models;
using BokaMust.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using System.Runtime.Intrinsics.Wasm;

namespace BokaMust.Controllers
{
    public class GuideController : Controller
    {

        private readonly List<Apple> _apples;
        private readonly List<Package> _packages;

        public GuideController()
        {
            _apples = GetApples(); 
            _packages = GetPackages();
        }

        private List<Apple> GetApples()
        {
            return new List<Apple>
            {
                new Apple ("Aroma", "Syrlig", "September"),
                new Apple ("Cox Orange", "Smakrik", "Oktober"),
                new Apple ("Discovery", "Smakrik", "Augusti"),
                new Apple ("Frida", "Syrlig", "November" ),
                new Apple ("Ingrid-Marie", "Frisk", "Oktober"),
                new Apple ("Rubinola", "Söt", "Oktober"),
                new Apple ("Signe Tilisch", "Söt","Oktober"),
                new Apple ("Transparante Blanche", "Syrlig","Augusti"),
                new Apple ("Åkerö", "Söt", "November"),
            };
        }

        private List<Package> GetPackages() 
        {
            return new List<Package>
            {
                new Package ("Råmust", 18),
                new Package ("Bag-in-box", 28),
            }; 
        }

        [HttpGet]
        public IActionResult GuideForm()
        {
            var viewModel = new GuideViewModel
            {
                Apples = _apples,
                Packages = _packages
            };
            return View(viewModel);
        }


        [HttpPost]
        public IActionResult GuideResults(GuideViewModel guideViewModel)
        {

            if (!ModelState.IsValid)
            {
                guideViewModel.Apples = GetApples();
                guideViewModel.Packages = GetPackages();

                return View("GuideForm", guideViewModel);
            }

            guideViewModel.Apples = GetApples();
            guideViewModel.Packages = GetPackages();
            guideViewModel.Price = CalculatePrice(guideViewModel.SelectedPackage, guideViewModel.Weight);

            return View("GuideResults", guideViewModel);
        }

        private double CalculatePrice(string selectedPackage, double weight)
        {
            var package = GetPackages().FirstOrDefault(p => p.Name == selectedPackage);
            if (package != null)
            {
                //Jag har valt 60% av vikten då man generellt får ut 50-70% av fruktens vikt i must
                return 0.6 * weight * package.Cost;
            }

            return 0; 
        }
    }
}
