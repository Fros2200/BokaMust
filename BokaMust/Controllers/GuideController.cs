﻿using BokaMust.Models;
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
            guideViewModel.Volume = CalculateVolume(guideViewModel.SelectedPackage, guideViewModel.Weight);
            guideViewModel.Price = CalculatePrice(guideViewModel.SelectedPackage, guideViewModel.Volume);
            guideViewModel.SessionTime = CalculateSessionTime(guideViewModel.Weight); 

            if(guideViewModel.SelectedPackage != null && guideViewModel.SelectedPackage == "Bag-in-box")
            {
                guideViewModel.NumberOfBib = CalculateNumOfBib(guideViewModel.Volume);
            }

            //Sparar guideviewmodel i sessionen
            var jsonModel= System.Text.Json.JsonSerializer.Serialize(guideViewModel);
            HttpContext.Session.SetString("GuideResults", jsonModel); 

            return View("GuideResults", guideViewModel);
        }

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

        private double CalculatePrice(string selectedPackage, double volume)
        {
            var package = GetPackages().FirstOrDefault(p => p.Name == selectedPackage);
            if (package != null)
            {
                return volume * package.Cost;
            }

            return 0; 
        }

        private double CalculateSessionTime(double weight)
        {

            if (weight <= 100)
            {
                return 0.5; 
            }
            else if(weight <= 199)
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

        private double CalculateNumOfBib(double volume)
        {
            return Math.Round(volume / 3); 
        }

    }
}
