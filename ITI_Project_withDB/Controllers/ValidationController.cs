using ITI_Project_withDB.Models;
using ITI_Project_withDB.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ITI_Project_withDB.Controllers
{
    public class ValidationController : Controller
    {
        private ITIContext context;
        public ValidationController()
        {
            context = new ITIContext();
        }
        // Add Course with validation

        [HttpGet]
        public IActionResult Add()
        {
            CourseVM course = new CourseVM()
            {
                instructors = new SelectList(context.Instructors,"Id","Name")
            };
            return View(course);
        }

        [HttpPost]
        public IActionResult Add(CourseVM course)
        {
            if (ModelState.IsValid)
            {
                Course newCourse = new Course() {
                Name = course.Name,
                Description = course.Description,
                FullMark = course.FullMark,
                PassMark = course.PassMark,
                totalHours = course.totalHours,
                ins_Id = course.ins_Id,
                };
                context.Courses.Add(newCourse);
                context.SaveChanges();
            return RedirectToAction("Index","Course");

            }
            course.instructors = new SelectList(context.Instructors, "Id", "Name");
            return View(course);
        }
    }
}
