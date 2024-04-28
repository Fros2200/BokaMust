using Microsoft.AspNetCore.Mvc;

namespace BokaMust.Controllers
{
    public class BookingController : Controller
    {
        public IActionResult BookingForm()
        {
            return View();
        }

        public IActionResult Calendar()
        {
            return View();
        }
    }
}
