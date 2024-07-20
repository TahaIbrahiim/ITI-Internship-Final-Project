using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITI_Project_withDB.ViewModels
{
    public class StudentCourseAddVM
    {
        public int Std_id { get; set; }
        public int Crs_id { get; set; }


        public int? grade { get; set; }


        public SelectList courses { get; set; }
        public SelectList students { get; set; }
    }
}
