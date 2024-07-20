
using ITI_Project_withDB.Models;
using ITI_Project_withDB.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ITI_Project_withDB.Controllers
{
    public class AccountController : Controller
    {
        private ITIContext context;
        public AccountController()
        {
            context = new ITIContext(); 
        }
        // Registration  => Add new user

        // Add New Data
        public IActionResult Register()
        {
            return View();
        }


        // Login    => Verfication of account (Authenticated user)
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(LoginVM login)
        {
            // validate model
            if (ModelState.IsValid)
            {
                // Check in  DB
                if (login.IsInstructor)
                {
                    // check in instructor table
                    Instructor instructor = context.Instructors.SingleOrDefault(i => i.Email == login.Email && i.Password == login.Password);
                    if (instructor != null)
                    {
                        // Authenticated user
                        // Save session data
                        HttpContext.Session.SetInt32("Id", instructor.Id);
                        HttpContext.Session.SetString("Name", instructor.Name);
                        HttpContext.Session.SetString("Type", nameof(Instructor));

                        // return view for user to start navigation in website
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        // unauthenticated user
                        ModelState.AddModelError("", "Wrong email or password");
                        return View(login);
                    }
                }
                else
                {
                    // check in student table
                    Student student = context.Students.SingleOrDefault(i => i.Email == login.Email && i.Password == login.Password);
                    if (student != null)
                    {
                        // Authenticated user
                        // Save session data
                        HttpContext.Session.SetInt32("Id", student.Id);
                        HttpContext.Session.SetString("Name", student.Name);
                        HttpContext.Session.SetString("Type", nameof(Student));


                        // return view for user to start navigation in website
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        // unauthenticated user
                        ModelState.AddModelError("", "Wrong email or password");
                        return View(login);
                    }
                }
            }
            else
            {
                return View(login);
            }
            
        }

        // Logout    => remove user data in session data
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }

    }
}
