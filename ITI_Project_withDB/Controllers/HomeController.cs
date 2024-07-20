using ITI_Project_withDB.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ITI_Project_withDB.Controllers
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

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult TestModel()
        {
            Student student = new Student()
            {
                Name = "Test",
                Address = "cairo"
            };
            Instructor instructor = new Instructor()
            {
                Name = "ali",
                Salary = 1000
            };
            return View(student);
        }
    }
}