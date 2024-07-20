using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITI_Project_withDB.Models
{
    [PrimaryKey("Std_id", "Crs_id")]
    public class StudentCourse
    {
        [ForeignKey("Student")]
        public int Std_id { get; set; }

        [ForeignKey("Course")]
        public int Crs_id { get; set; }


        public int? grade { get; set; }


        // Navigation Property
        public Student Student { get; set; }
        public Course Course { get; set; }
    }
}
