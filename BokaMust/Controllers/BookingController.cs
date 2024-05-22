using BokaMust.Models;
using BokaMust.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace BokaMust.Controllers
{
    public class BookingController : Controller
    {

        private List<TimeSlot> GetTimeSlots() 
        {
            return new List<TimeSlot>
            {
                new TimeSlot ("Augusti","15","Torsdag","09:00 - 09:30",0.5),
                new TimeSlot ("Augusti","15","Torsdag","09:30 - 10:00",0.5),
                new TimeSlot ("Augusti","15","Torsdag","10:00 - 11:00",1),
                new TimeSlot ("Augusti","15","Torsdag","11:00 - 13:00",2),
                new TimeSlot ("Augusti","15","Torsdag","13:00 - 16:00",3),
                new TimeSlot ("Augusti","15","Torsdag","16:00 - 20:00",4),
                new TimeSlot ("Augusti","16","Fredag","09:00 - 14:00",5),
                new TimeSlot ("Augusti","17","Lördag","09:00 - 09:30",0.5),
                new TimeSlot ("Augusti","17","Lördag","09:30 - 10:00",0.5),

                new TimeSlot ("September","13","Fredag","09:00 - 09:30",0.5),
                new TimeSlot ("September","13","Fredag","09:30 - 10:00",0.5),
                new TimeSlot ("September","13","Fredag","10:00 - 11:00",1),
                new TimeSlot ("September","13","Fredag","11:00 - 13:00",2),
                new TimeSlot ("September","13","Fredag","13:00 - 16:00",3),
                new TimeSlot ("September","13","Fredag","16:00 - 20:00",4),
                new TimeSlot ("September","14","Lördag","09:00 - 14:00",5),
                new TimeSlot ("September","15","Söndag","09:00 - 09:30",0.5),
                new TimeSlot ("September","15","Söndag","09:30 - 10:00",0.5),

                new TimeSlot ("Oktober","11","Fredag","09:00 - 09:30",0.5),
                new TimeSlot ("Oktober","11","Fredag","09:30 - 10:00",0.5),
                new TimeSlot ("Oktober","11","Fredag","10:00 - 11:00",1),
                new TimeSlot ("Oktober","11","Fredag","11:00 - 13:00",2),
                new TimeSlot ("Oktober","11","Fredag","13:00 - 16:00",3),
                new TimeSlot ("Oktober","11","Fredag","16:00 - 20:00",4),
                new TimeSlot ("Oktober","12","Lördag","09:00 - 14:00",5),
                new TimeSlot ("Oktober","13","Söndag","09:00 - 09:30",0.5),
                new TimeSlot ("Oktober","13","Söndag","09:30 - 10:00",0.5),

                new TimeSlot ("November","15","Fredag","09:00 - 09:30",0.5),
                new TimeSlot ("November","15","Fredag","09:30 - 10:00",0.5),
                new TimeSlot ("November","15","Fredag","10:00 - 11:00",1),
                new TimeSlot ("November","15","Fredag","11:00 - 13:00",2),
                new TimeSlot ("November","15","Fredag","13:00 - 16:00",3),
                new TimeSlot ("November","15","Fredag","16:00 - 20:00",4),
                new TimeSlot ("November","16","Lördag","09:00 - 14:00",5),
                new TimeSlot ("November","17","Söndag","09:00 - 09:30",0.5),
                new TimeSlot ("November","17","Söndag","09:30 - 10:00",0.5),
            };
        }


        public IActionResult BookingForm()
        {
            return View();
        }

        public IActionResult AvailableTimes()
        {
            var modelJson = HttpContext.Session.GetString("GuideResults");
            if (string.IsNullOrEmpty(modelJson))
            {
                return RedirectToAction("Error");
            }

            var guideViewModel = JsonSerializer.Deserialize<GuideViewModel>(modelJson);
            var availableTimes = FindAvailableTimeSlots(guideViewModel);

            return View("Calendar", availableTimes);
        }

        public List<TimeSlot> FindAvailableTimeSlots(GuideViewModel guideViewModel)
        {
            var selectedApple = guideViewModel.Apples?.FirstOrDefault(a => a.Name == guideViewModel.SelectedApple);

            string harvestMonth = selectedApple.HarvestMonth; 

            var allSlots = GetTimeSlots();
            var matchedSlots = allSlots.Where(slot =>
            slot.Month == harvestMonth && slot.Duration == guideViewModel.SessionTime).ToList(); 

            return matchedSlots; 
        }

        [HttpPost]
        public IActionResult BookTimeSlot(TimeSlot timeSlot)
        {
            
            return View("BookingConfirmation", timeSlot);
        }

        public IActionResult ShowCalendar()
        { 
            
            return View("Calendar"); 
        }
    }
}
