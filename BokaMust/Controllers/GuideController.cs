using BokaMust.Models;
using BokaMust.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using System.Runtime.Intrinsics.Wasm;

namespace BokaMust.Controllers
{
    public class GuideController : Controller
    {
        #region Variables
        private readonly List<Apple> _apples;
        private readonly List<Package> _packages;
        #endregion

        #region Constructors
        public GuideController()
        {
            _apples = GetApples();
            _packages = GetPackages();
        }
        #endregion

        #region Action methods GET

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

        #endregion

        #region Action methods POST

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
            guideViewModel.Volume = CalculateVolume(guideViewModel.SelectedPackage, guideViewModel.Weight);
            guideViewModel.Price = CalculatePrice(guideViewModel.SelectedPackage, guideViewModel.Volume);
            guideViewModel.SessionTime = CalculateSessionTime(guideViewModel.Weight);

            if (guideViewModel.SelectedPackage != null && guideViewModel.SelectedPackage == "Bag-in-box")
            {
                guideViewModel.NumberOfBib = CalculateNumOfBib(guideViewModel.Volume);
            }

            //Sparar guideviewmodel i sessionen
            var jsonModel = System.Text.Json.JsonSerializer.Serialize(guideViewModel);
            HttpContext.Session.SetString("GuideResults", jsonModel);

            return View("GuideResults", guideViewModel);
        }

        #endregion

        #region Helper methods

        /// <summary>
        /// Skapar en lista av fördefinerade Apple-objekt. Varje Apple har ett Name, Description och HarvestMonth.
        /// </summary>
        /// <returns>Lista med Apple-objekt, idag 9st</returns>
        private List<Apple> GetApples()
        {
            return new List<Apple>
            {
                new Apple ("Aroma", "Syrligt", "September"),
                new Apple ("Cox Orange", "Smakrikt", "Oktober"),
                new Apple ("Discovery", "Smakrikt", "Augusti"),
                new Apple ("Frida", "Syrligt", "November" ),
                new Apple ("Ingrid-Marie", "Friskt", "Oktober"),
                new Apple ("Rubinola", "Sött", "Oktober"),
                new Apple ("Signe Tilisch", "Sött","Oktober"),
                new Apple ("Transparante Blanche", "Syrligt","Augusti"),
                new Apple ("Åkerö", "Sött", "November"),
            };
        }

        /// <summary>
        /// Skapar lista av Package-objekt. Varje objekt har ett Name och ett Price
        /// </summary>
        /// <returns>En fördefinerad lista av förpackningstyper, just nu två stycken</returns>
        private List<Package> GetPackages()
        {
            return new List<Package>
            {
                new Package ("Råmust", 18),
                new Package ("Bag-in-box", 28),
            };
        }

        /// <summary>
        /// Räknar ut ungefärlig volym äppelmust som användaren få ut baserat på angiven vikt
        /// </summary>
        /// <param name="selectedPackage">Vald förpackningstyp</param>
        /// <param name="weight">Angiven vikt i kg</param>
        /// <returns>Ungefärlig volym, just nu 60% av angiven vikt</returns>
        private double CalculateVolume(string selectedPackage, double weight)
        {
            var package = GetPackages().FirstOrDefault(m => m.Name == selectedPackage);
            if (package != null)
            {
                //Jag har valt 60% av vikten då man generellt får ut 50-70% av fruktens vikt i must
                //Denna funktion skulle man kunna bygga ut och göra mer dynamisk baserat på vald äpplesort etc
                return Math.Round(0.6 * weight);
            }
            return 0;
        }

        /// <summary>
        /// Räknar ut ungefärligt pris som användaren beräknas få betala för sin must. Baseras på volym och vald förpackningstyp. 
        /// </summary>
        /// <param name="selectedPackage">Vilken förpackningstyp som användaren valt</param>
        /// <param name="volume">Parameter som tas fram i CalculateVolum, baseras på angiven vikt</param>
        /// <returns>Ungefärligt pris</returns>
        private double CalculatePrice(string selectedPackage, double volume)
        {
            var package = GetPackages().FirstOrDefault(p => p.Name == selectedPackage);
            if (package != null)
            {
                return volume * package.Cost;
            }

            return 0;
        }

        /// <summary>
        /// Räknar ut tidsåtgång för äppelmustningen baserat på den vikt i kg som användaren angett
        /// </summary>
        /// <param name="weight">Weight = mängd äpplen i kg angiven av användaren</param>
        /// <returns>Tidsåtgång för mustningen, tidsspannet är mellan 0.5h-5h</returns>
        private double CalculateSessionTime(double weight)
        {

            if (weight <= 100)
            {
                return 0.5;
            }
            else if (weight <= 199)
            {
                return 1;
            }
            else if (weight <= 299)
            {
                return 2;
            }
            else if (weight <= 399)
            {
                return 3;
            }
            else if (weight <= 499)
            {
                return 4;
            }
            else
            {
                return 5;
            }
        }

        /// <summary>
        /// Ränkar ut hur många BiB som användaren kommer få ut baserat på den volym must som räknas ut i CalculateVolume
        /// En BiB håller 3l, därför delas volymen med 3.
        /// </summary>
        /// <param name="volume">Parameter som tas fram i CalculateVolum, baseras på angiven vikt</param>
        /// <returns>Antal BiB användaren får ut</returns>
        private double CalculateNumOfBib(double volume)
        {
            return Math.Round(volume / 3);
        }

        #endregion









    }
}
