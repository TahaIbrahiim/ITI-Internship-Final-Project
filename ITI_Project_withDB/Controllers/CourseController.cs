using ITI_Project_withDB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ITI_Project_withDB.Controllers
{
    public class CourseController : Controller
    {
        private ITIContext context;
        public CourseController()
        {
            context = new ITIContext();
        }
        // get all
        public IActionResult Index()
        {
            // get data from DB
            List<Course> courses = context.Courses.ToList();

            // return view with data
            return View(courses);
        }
        public IActionResult Details(int id)
        {
            // get course data
            Course course = context.Courses.Include(c=>c.Instructor).SingleOrDefault(c=>c.Id==id);

            if(course == null)
            {
                return Content("Error");
            }
            // return view with data
            return View(course);
        }

        public IActionResult AddForm()
        {
            List<Instructor> instructors = context.Instructors.ToList();
            ViewBag.Ins = instructors;
            return View();
        }

        public IActionResult AddInDB(Course course)
        {
            context.Courses.Add(course);
            context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult EditForm(int id)
        {
            Course course = context.Courses.SingleOrDefault(c=>c.Id== id);

            ViewBag.Ins = context.Instructors.ToList();
            return View(course);
        }

        public IActionResult EditInDB(Course course)
        {
            Course OldCourse = context.Courses.SingleOrDefault(c=>c.Id == course.Id);

            OldCourse.Name = course.Name;
            OldCourse.Description = course.Description;
            OldCourse.FullMark = course.FullMark;
            OldCourse.totalHours = course.totalHours;
            OldCourse.PassMark = course.PassMark;
            OldCourse.ins_Id = course.ins_Id;

            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            Course course = context.Courses.SingleOrDefault(c => c.Id == id);
            context.Courses.Remove(course);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
