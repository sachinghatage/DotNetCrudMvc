using Microsoft.EntityFrameworkCore;
using StudentPortal.Models.Entities;

namespace StudentPortal.Data
{
    public class ApplicatinDbContext: DbContext
    {
        public ApplicatinDbContext(DbContextOptions<ApplicatinDbContext> options):base(options) 
        {
            
        }


        public DbSet<Student> Students { get; set; }
    }
}
