using demo_application.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace demo_application.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
    }
}
