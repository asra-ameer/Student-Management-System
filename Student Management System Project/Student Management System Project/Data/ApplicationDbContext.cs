using Microsoft.EntityFrameworkCore;
using Student_Management_System_Project.Model.Entity;

namespace Student_Management_System_Project.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions options): base(options) {

        }
        public  DbSet<Student> Students { get; set; }
    }
}
