using ITI_Project_withDB.Models;
using Microsoft.AspNetCore.Mvc;

namespace ITI_Project_withDB.Controllers
{
    public class StudentController : Controller
    {
        private ITIContext context;
        public StudentController()
        {
            context = new ITIContext();
        }
        // get all students
        public IActionResult Index()
        {
            List<Student> students = context.Students.ToList();

            return View(students);
            //return View();   // ViewName =  Index  ,  Model = null
            //return View(students);  // ViewName =  Index  ,  Model = students
            //return View("GetAll", students); // ViewName =  GetAll  ,  Model = students
            //return View("GetAll"); // ViewName =  GetAll  ,  Model = null
        }

        public IActionResult Details(int id)
        {
            Student student = context.Students.Where(s => s.Id == id).SingleOrDefault();
            if(student == null)
            {
                return Content("Error");
            }
            return View(student);
        }

        public IActionResult NewForm()
        {
            return View();
        }

        public IActionResult AddToDB(Student student)
        {
            context.Students.Add(student);
            context.SaveChanges();

            return RedirectToAction("Login","Account");
        }
    }
}
