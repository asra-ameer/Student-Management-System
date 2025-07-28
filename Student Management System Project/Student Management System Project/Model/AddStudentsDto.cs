namespace Student_Management_System_Project.Model
{
    public class AddStudentsDto
    {
        public Guid id { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
        public required string FollowingDegree { get; set; }
        public string? Address { get; set; }
    }
}
