using ITI_Project_withDB.Models;
using ITI_Project_withDB.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ITI_Project_withDB.Controllers
{
    public class StudentCourseController : Controller
    {
        ITIContext context;
        public StudentCourseController()
        {
            context = new ITIContext();
        }
        public IActionResult GetStudentCourses()
        {
            // get student id from session
            int? studentID = HttpContext.Session.GetInt32("Id");
            if(studentID.HasValue)
            {
                // user is authenticated , login done successfully
                List<StudentCourse> studentCourses = context.StudentCourses.Include(sc=>sc.Student).Include(sc=>sc.Course).Where(sc=>sc.Std_id == studentID.Value).ToList();

                //ToDo:  check on studentCourses list count

                StudentCourseVM studentCoursesVM = new StudentCourseVM()
                {
                    Std_id = studentID.Value,
                    // Std_Name = studentCourses[0].Student.Name,
                    Std_Name = HttpContext.Session.GetString("Name"),
                    Courses = new List<CourseDeatailsVM>()
                };

                foreach (var item in studentCourses)
                {
                    studentCoursesVM.Courses.Add(new CourseDeatailsVM
                    {
                        Crs_id = item.Crs_id,
                        Crs_Name = item.Course.Name,
                        Grade = item.grade
                    });
                }

                return View(studentCoursesVM);
            }
            else
            {
              return  RedirectToAction("Login", "Account");
            }     
        }

        public IActionResult Index()
        {
            List<StudentCourse> studentCourses = context.StudentCourses.Include(sc => sc.Student).Include(sc => sc.Course).ToList();

            List<AllStudentCoursesVM> allStudentCourses = new List<AllStudentCoursesVM>(); 

            foreach(var sc in studentCourses)
            {
                allStudentCourses.Add(new AllStudentCoursesVM
                {
                    Std_id = sc.Std_id,
                    Std_Name = sc.Student.Name,
                    Crs_id = sc.Crs_id,
                    Crs_Name = sc.Course.Name,
                    Grade = sc.grade.Value
                });
            }

            return View(allStudentCourses);
        }

        [HttpGet]
        public IActionResult Add()
        {
            StudentCourseAddVM addVM = new StudentCourseAddVM()
            {
                courses = new SelectList(context.Courses, "Id", "Name"),
                students = new SelectList(context.Students,"Id", "Name"),   
            };
            return View(addVM);
        }
        [HttpPost]
        public IActionResult Add(StudentCourseAddVM addVM)
        {
            StudentCourse studentCourse = new StudentCourse()
            {
                Std_id = addVM.Std_id,
                Crs_id = addVM.Crs_id,
                grade = addVM.grade
            };

            context.StudentCourses.Add(studentCourse);
            context.SaveChanges();
           return RedirectToAction("Index");
        }
    }
}
