using CMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Persistence.Contexts;

public class CMSDbContext : DbContext
{
    public DbSet<Attendance> Attendances { get; set; }
    public DbSet<Class> Classes { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<CourseGroup> CourseGroups { get; set; }
    public DbSet<CourseSchedule> CourseSchedules { get; set; }
    public DbSet<Exam> Exams { get; set; }
    public DbSet<ExamResult> ExamResults { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<Student> Students { get; set; }
    public DbSet<StudentCourse> StudentCourses { get; set; }
    public DbSet<Teacher> Teachers { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Server=YOUR_SERVER;Database=CMSDB;Trusted_Connection=true;TrustServerCertificate=True");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        foreach (var foreignKey in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
        {
            foreignKey.DeleteBehavior = DeleteBehavior.Restrict;
        }

        base.OnModelCreating(modelBuilder);

    }

}
