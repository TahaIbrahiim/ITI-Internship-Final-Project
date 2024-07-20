using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITI_Project_withDB.Models
{
    public class Instructor
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int? Salary { get; set; }
        public int? Age { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }

        [ForeignKey("Department")]
        [Display(Name = "Department")]
        public int? Dept_Id { get; set; }

        // Navigation Property
        public List<Course>? Courses { get; set; }
        public Department Department { get; set; }

        public override string ToString()
        {
            return $"name: {Name}, salary: {Salary}";
        }
    }
}
