using BokaMust.Models;
using Microsoft.AspNetCore.Mvc;

namespace BokaMust.Controllers
{
    public class GuideController : Controller
    {

        public IActionResult GuideForm()
        {
            return View();
        }

        public IActionResult GuideResults() 
        {
            return View(); 
        }


        [HttpPost]
        public IActionResult Save(GuideViewModel guideViewModel)
        {
            //string selectedZone = guideViewModel.SelectedZone;
            string selectedApple = guideViewModel.SelectedApple;
            string selectedPackaging = guideViewModel.SelectedPackaging;
            decimal weight = guideViewModel.Weight;

            string result = $"Du vill musta {weight}kg av {selectedApple} och förpacka din must som {selectedPackaging}";

            return View("GuideResults", result);
        }
        

        public int calculateCost(GuideViewModel guideViewModel)
        {
            int weight = guideViewModel.Weight; 
            string packaging = guideViewModel.SelectedPackaging.ToString();

            int rawmust = 18;
            int bib = 28;


            if(packaging == "rawmust")
            {
                int cost = weight * rawmust;
                return cost;
            }
            else if(packaging == "bib")
            {
                int cost = weight * bib;
                return cost;
            }
            return 0;            
        }


    }
}
