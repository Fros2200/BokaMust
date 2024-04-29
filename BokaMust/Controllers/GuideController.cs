using BokaMust.Models;
using BokaMust.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BokaMust.Controllers
{
    public class GuideController : Controller
    {

        public IActionResult GuideForm()
        {
            return View();
        }

        //public IActionResult GuideResults() 
        //{
        //    return View(); 
        //}

        [HttpPost]
        public IActionResult GuideResults(GuideViewModel guideViewModel)
        {
            int price = guideViewModel.CalculatePrice();

            if(guideViewModel.SelectedApple.Weight < 30)
            {
                ModelState.AddModelError("SelectedApple.Weight", "Vikten måste vara minst 30kg");
                return View(guideViewModel);
            }

            return View(guideViewModel);
        }


        //public IActionResult GuideResults(GuideViewModel guideViewModel)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        ViewData["UserInput"] = guideViewModel;
        //        return View("Success");
        //    }
        //    else
        //    {
        //        return View(guideViewModel);
        //    }
        //}


            //[HttpPost]
            //public IActionResult Save(GuideViewModel guideViewModel)
            //{
            //    //string selectedZone = guideViewModel.SelectedZone;
            //    string selectedApple = guideViewModel.SelectedApple;
            //    string selectedPackaging = guideViewModel.SelectedPackaging;
            //    decimal weight = guideViewModel.Weight;

            //    string result = $"Du vill musta {weight}kg av {selectedApple} och förpacka din must som {selectedPackaging}";

            //    return View("GuideResults", result);
            //}





            public void GetAppleData()
        {

        }
    }
}
