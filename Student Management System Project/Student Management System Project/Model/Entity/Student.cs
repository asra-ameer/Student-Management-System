namespace Student_Management_System_Project.Model.Entity
{
    public class Student
    {
        public Guid id { get; set; }
        public  required string  Name { get; set; }
        public required string Email { get; set; }
        public required string FollowingDegree { get; set; }
        public  string? Address { get; set; }
    }
}
