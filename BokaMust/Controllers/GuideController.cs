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


        [HttpPost]
        public IActionResult Save(GuideViewModel guideViewModel)
        {
            string selectedZone = guideViewModel.SelectedZone;
            string selectedApple = guideViewModel.SelectedApple;
            string selectedRadioButton = guideViewModel.SelectedPackaging;
            decimal weight = guideViewModel.Weight;

            string result = "Du har fått info från din controller ut i vyn";

            return View("GuideResults", result);
        }
        



        //[HttpPost]
        //public IActionResult CalculateGuideResults()
        //{
        //    return View();
        //}

        //public IActionResult Index()
        //{
        //    return View();
        //}
    }
}
