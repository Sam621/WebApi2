using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using WebAPI.Data.Model;

namespace WebAPI.Data
{
    public class SchoolContext : DbContext
    {
        public SchoolContext() : base("SchoolContext")
        {
        }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }      
        public DbSet<Student> Students { get; set; }
     
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            //modelBuilder.Entity<Course>()
            //    .HasMany(c => c.Instructors).WithMany(i => i.Courses)
            //    .Map(t => t.MapLeftKey("CourseID")
            //        .MapRightKey("InstructorID")
            //        .ToTable("CourseInstructor"));

            //modelBuilder.Entity<Department>().MapToStoredProcedures();
        }
    }
}
