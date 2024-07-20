using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace ITI_Project_withDB.ViewModels
{
    public class CourseVM
    {

        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [StringLength(200,MinimumLength =50)]
        public string? Description { get; set; }
        [Range(10,100)]
        [Display(Name = "Total Hours")]
        public int? totalHours { get; set; }
        public int? FullMark { get; set; }
        public int? PassMark { get; set; }
        [Display(Name = "Instructor")]
        public int? ins_Id { get; set; }

        //Minimum eight characters, at least one letter and one number
        [RegularExpression("^(?=.*[A-Za-z])(?=.*[0-9])[A-Za-z0-9]{8,}$")]
        public string Password { get; set; }

        [Compare("Password")]
        public string ConfirmPassword { get; set; }

        [ValidateNever]
        public SelectList instructors { get; set; }
    }

}
