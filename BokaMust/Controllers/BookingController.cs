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
                new TimeSlot ("Augusti","15","09:00 - 09:30",0.5),
                new TimeSlot ("Augusti","15","09:30 - 10:00",0.5),
                new TimeSlot ("Augusti","15","10:00 - 11:00",1),
                new TimeSlot ("Augusti","15","11:00 - 13:00",2),
                new TimeSlot ("Augusti","15","13:00 - 16:00",3),
                new TimeSlot ("Augusti","15","16:00 - 20:00",4),
                new TimeSlot ("Augusti","16","09:00 - 14:00",5),

                new TimeSlot ("September","15","09:00 - 09:30",0.5),
                new TimeSlot ("September","15","09:30 - 10:00",0.5),
                new TimeSlot ("September","15","10:00 - 11:00",1),
                new TimeSlot ("September","15","11:00 - 13:00",2),
                new TimeSlot ("September","15","13:00 - 16:00",3),
                new TimeSlot ("September","15","16:00 - 20:00",4),
                new TimeSlot ("September","16","09:00 - 14:00",5),

                new TimeSlot ("Oktober","15","09:00 - 09:30",0.5),
                new TimeSlot ("Oktober","15","09:30 - 10:00",0.5),
                new TimeSlot ("Oktober","15","10:00 - 11:00",1),
                new TimeSlot ("Oktober","15","11:00 - 13:00",2),
                new TimeSlot ("Oktober","15","13:00 - 16:00",3),
                new TimeSlot ("Oktober","15","16:00 - 20:00",4),
                new TimeSlot ("Oktober","16","09:00 - 14:00", 5),

                new TimeSlot ("November","15","09:00 - 09:30",0.5),
                new TimeSlot ("November","15","09:30 - 10:00",0.5),
                new TimeSlot ("November","15","10:00 - 11:00",1),
                new TimeSlot ("November","15","11:00 - 13:00",2),
                new TimeSlot ("November","15","13:00 - 16:00",3),
                new TimeSlot ("November","15","16:00 - 20:00",4),
                new TimeSlot ("November","16","09:00 - 14:00", 5),
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
            var allSlots = GetTimeSlots();
            var matchedSlots = allSlots.Where(slot =>
            slot.Duration == guideViewModel.SessionTime).ToList(); 

            return matchedSlots; 
        }



        [HttpPost]
        public IActionResult BookTimeSlot(TimeSlot timeSlot)
        {
            
            return View("BookingConfirmation", timeSlot);
        }
    }
}
