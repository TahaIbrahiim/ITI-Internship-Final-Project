using ITI_Project_withDB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace ITI_Project_withDB.Controllers
{
    public class InstructorController : Controller
    {
        private ITIContext context;
        public InstructorController()
        {
            context = new ITIContext();
        }
        public IActionResult Index()
        {
            List<Instructor> instructors = context.Instructors.ToList();
            return View(instructors);
        }

        public IActionResult Details(int id)
        {
            Instructor instructor = context.Instructors.Include(i=>i.Department).SingleOrDefault(i=>i.Id == id);

            return View(instructor);
        }

        [HttpGet]
        public IActionResult Add()
        {
           List<Department> departments = context.Departments.ToList();
            ViewBag.depts = new SelectList(departments,"Id","Name");
            return View();
        }
        [HttpPost]
        public IActionResult Add(Instructor instructor)
        {
            context.Instructors.Add(instructor);
            context.SaveChanges();
            return RedirectToAction("Login", "Account");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Instructor instructor = context.Instructors.SingleOrDefault(i => i.Id == id);
            List<Department> departments = context.Departments.ToList();
            ViewBag.depts = new SelectList(departments, "Id", "Name");
            return View(instructor);
        }
        [HttpPost]
        public IActionResult Edit(Instructor instructor)
        {
            context.Instructors.Update(instructor);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            Instructor instructor = context.Instructors.SingleOrDefault(i=>i.Id == id);

            context.Instructors.Remove(instructor);
            context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
