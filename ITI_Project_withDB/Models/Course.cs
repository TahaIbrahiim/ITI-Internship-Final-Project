using System.ComponentModel.DataAnnotations.Schema;

namespace ITI_Project_withDB.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int? totalHours { get; set; }
        public int? FullMark { get; set; }
        public int? PassMark { get; set; }


        // Foriegn keys
        [ForeignKey("Instructor")]
        public int? ins_Id { get; set; }


        // Navigation Property
        public Instructor? Instructor { get; set; }
        public List<StudentCourse>? studentCourses { get; set; }
    }
}
