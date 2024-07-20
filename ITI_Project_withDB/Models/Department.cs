namespace ITI_Project_withDB.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }


        // Navigation Property
        public List<Instructor> Instructors { get; set; }
    }
}
