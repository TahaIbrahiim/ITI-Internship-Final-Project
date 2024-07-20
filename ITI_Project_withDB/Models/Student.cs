namespace ITI_Project_withDB.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public int? Age { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Img { get; set; }


        // Navigation Property
        public List<StudentCourse>? studentCourses { get; set; }


        public override string ToString()
        {
            return $"name: {Name}, address: {Address}";
        }
    }
}
