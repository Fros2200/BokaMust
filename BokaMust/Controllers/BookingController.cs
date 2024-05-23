using BokaMust.Models;
using BokaMust.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace BokaMust.Controllers
{
    public class BookingController : Controller
    {
        #region Action methods GET
        
        /// <summary>
        /// Hanterar förfrågningar för att visa BookingForm-vyn. 
        /// </summary>
        /// <returns>BookingForm-vyn</returns>
        public IActionResult BookingForm()
        {
            return View();
        }

        /// <summary>
        /// Hanterar förfrågningar för Calendar vyn. 
        /// Om TempData innehåller MatchedTimeSlots så deserialiseras det och skickas till vyn som en lista med matchade tider.
        /// TempData sparas också så att användaren ska kunna gå mellan Calendar-vyn och SelectedTime-vyn utan att matchade försvinner. 
        /// Om TempData är tomt, returnerar vyn med en tomlista av TimeSlot objekt
        /// </summary>
        /// <returns>Calendar vyn med en lista av TimeSlot object</returns>
        public IActionResult Calendar()
		{
			if (TempData["MatchedTimeSlots"] != null) 
			{
                var matchedSlots = JsonSerializer.Deserialize<List<TimeSlot>>(TempData["MatchedTimeSlots"].ToString());
                TempData.Keep("MatchedTimeSlots"); 
                return View(matchedSlots);
			}

			return View(new List<TimeSlot>());
		}

        /// <summary>
        /// När användaren klickar på 'Hitta ledig tid' i GuideResults-vyn körs denna metod för at visa tillgängliga tider. 
        /// 1. Hämtar GuideViewModel från sessionen.
        /// 2. Hittar matchande tider. 
        /// 3. Returnerar Calendar-vyn med de tillgängliga tiderna.
        /// 4. Omdirigerar till Error-vyn sessionens data saknas eller är ogiltigt. 
        /// </summary>
        /// <returns>Calendar-vyn med en lista av tillgängliga TimeSlot-objekt om sessionens data är giltigt, annars omdirigerar den till Error-vyn.</returns>
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

        /// <summary>
        /// Hanterar bokningsåtgärder baserat på den angivna parametern 'action'.
        /// Omdirigerar användaren baserat på hens knappval. 
        /// FindNewBooking omdirigerar till Calendar-vyn. ConfirmBooking omdirigerar till BookingConfrimation-vyn.
        /// Om 'action'-parametern inte matchar något av fallen returneras Calendar-vyn.
        /// </summary>
        /// <param name="action">Strängparameter som bestämmer vilken åtgärd som ska utföras.</param>
        /// <returns>Omdirigering till Calendar-vyn eller BookingConfirmation-vyn baserat på 'action'-parametern.</returns>
        public IActionResult HandleBooking(string action)
        {
            if (action == "FindNewBooking")
            {
                return RedirectToAction("Calendar");
            }
            else if (action == "ConfirmBooking")
            {
                return RedirectToAction("BookingConfirmation");
            }
            return View("Calendar");
        }

        /// <summary>
        /// Hanterar förfrågningar för att visa BookingConfrimation-vyn.
        /// 1. Hämtar TimeSlot-objektet från TempData, om den finns.
        /// 2. Skickar TimeSlot-objektet till vyn.
        /// 3. Returnerar vyn utan modell om inget TimeSlot-objekt hittas i TempData.
        /// </summary>
        /// <returns>BookingConfrimation-vyn med ett TimeSlot-objekt om det finns i TempData, annars returneras vyn utan modell</returns>
        public IActionResult BookingConfirmation()
        {
            if (TempData["TimeSlot"] != null)
            {
                var timeSlot = JsonSerializer.Deserialize<TimeSlot>(TempData["TimeSlot"].ToString());
                return View(timeSlot);
            }
            return View();
        }

        #endregion

        #region Action methods POST

        /// <summary>
        /// Hanterar POST förfrågningar för att spara vald tid.
        /// Serialiserar det valda TimeSlot-objektet och lagrar det i TempData.
        /// </summary>
        /// <param name="timeSlot">TimeSlot-objekt som representerar den valda tiden</param>
        /// <returns>SelectedTime-vyn med det valda TimeSlot-objektet</returns>
        [HttpPost]
        public IActionResult SelectedTime(TimeSlot timeSlot)
        {
            TempData["TimeSlot"] = JsonSerializer.Serialize(timeSlot);

            return View(timeSlot);
        }

        #endregion

        #region Helper methods

        /// <summary>
        /// Skapar och returnerar en fördefinerad lista med tillgängliga tider.
        /// Varje tid innehåller information om månad, datum, veckodag, tid samt varaktighet.
        /// </summary>
        /// <returns>En lista med fördefinerade TimeSlot objekt som representerar tillgängliga tider.</returns>
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

		/// <summary>
		/// Hittar och returnerar en lista med tillgängliga tider som matchar angivna kriterier från guideViewModel.
        /// Om användaren inte angett äppelsort så hämtas baserat på SessonTime. 
        /// Om användaren angett äppelsort filtreras tiderna baserat på det valda äpplets HarvestMonth och SessionTime.
        /// Tillgängliga tider sparas i TempData som MatchedTimeSlots.
		/// </summary>
		/// <param name="guideViewModel">Innehåller information om det valda äpplet samt sessionstid</param>
		/// <returns>En lista av TimeSlot objekt som matchar de angivna kriterierna.</returns>
		public List<TimeSlot> FindAvailableTimeSlots(GuideViewModel guideViewModel)
		{
            if (guideViewModel.SelectedApple == "unknownApple") //om användaren inte angett äppelsort så tider baserat på sessionTime
            {
                var allSlots = GetTimeSlots();
                var matchedSlots = allSlots.Where(slot =>
                slot.Duration == guideViewModel.SessionTime).ToList();

                TempData["MatchedTimeSlots"] = JsonSerializer.Serialize(matchedSlots); 
                return matchedSlots; 
            }
            else
            {
                var selectedApple = guideViewModel.Apples?.FirstOrDefault(a => a.Name == guideViewModel.SelectedApple);
                string harvestMonth = selectedApple.HarvestMonth;

                var allSlots = GetTimeSlots();
                var matchedSlots = allSlots.Where(slot =>
                slot.Month == harvestMonth && slot.Duration == guideViewModel.SessionTime).ToList();

                TempData["MatchedTimeSlots"] = JsonSerializer.Serialize(matchedSlots);

                return matchedSlots;
            }
		}

		#endregion
	}
}
