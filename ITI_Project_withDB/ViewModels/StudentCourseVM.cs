namespace ITI_Project_withDB.ViewModels
{
    public class StudentCourseVM
    {
        public int Std_id { get; set; }
        public string Std_Name { get; set; }

        public List<CourseDeatailsVM> Courses { get; set; }
    }

    public class CourseDeatailsVM
    {
        public int Crs_id { get; set; }
        public string Crs_Name { get; set; }
        public int? Grade { get; set; }
    }
}
