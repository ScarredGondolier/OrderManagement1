using Microsoft.AspNetCore.Mvc;
using OrderManagementApp.Managers;
using OrderManagementApp.Models;
using System.Diagnostics;

namespace OrderManagementApp.Controllers
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
            OrderManagementApiClient orderManagementApiClient = new OrderManagementApiClient();
            return View(orderManagementApiClient.GetAllOrders());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

