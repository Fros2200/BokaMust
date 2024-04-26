using BokaMust.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BokaMust.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;

		public HomeController(ILogger<HomeController> logger)
		{
			_logger = logger;
		}

		public IActionResult Index()
		{
			return View();
		}

		//public IActionResult BookingOne()
		//{
		//	return View();
		//}

		//public IActionResult GuideForm()
		//{
		//	return View();
		//}

		//public IActionResult GuideResults()
		//{
		//	return View();
		//}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
