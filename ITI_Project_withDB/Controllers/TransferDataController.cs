using ITI_Project_withDB.Models;
using ITI_Project_withDB.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ITI_Project_withDB.Controllers
{
    public class TransferDataController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SetViewData(string name, int age)
        {
            ViewData["name"] = name;
            ViewData["age"] = age;
            return View();
        }

        public IActionResult SetViewBag(string name, int age)
        {
            //set values
            ViewBag.name = name;
            ViewBag.age = age;


            ViewData["testData"] = "Welcome";
            ViewBag.testBag = "Ali";
            return View();        
        }

        // Model Binder
        public IActionResult SetModel(Student std)
        {
            return View(std);
        }

        public IActionResult setViewModel(studentDataVM studentData)
        {
            return View(studentData);
        }
    }
}
