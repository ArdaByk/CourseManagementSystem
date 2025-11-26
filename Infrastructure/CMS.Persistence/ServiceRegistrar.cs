using CMS.Application.Abstractions.Services;
using CMS.Persistence.Contexts;
using CMS.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Persistence;

public static class ServiceRegistrar
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services)
    {
        services.AddDbContext<CMSDbContext>();

        services.AddScoped<IStudentService, StudentManager>();
        services.AddScoped<ITeacherService, TeacherManager>();
        services.AddScoped<ICourseService, CourseManager>();
        services.AddScoped<IClassService, ClassManager>();
        services.AddScoped<ISpecializationService, SpecializationManager>();
        services.AddScoped<ITeacherSpecializationService, TeacherSpecializationManager>();
        services.AddScoped<IExamService, ExamManager>();
        services.AddScoped<IExamResultService, ExamResultManager>();
        services.AddScoped<IRoleService, RoleManager>();
        services.AddScoped<IUserService, UserManager>();
        services.AddScoped<ICourseGroupService, CourseGroupManager>();
        services.AddScoped<ICourseScheduleService, CourseScheduleManager>();
        services.AddScoped<IStudentCourseService, StudentCourseManager>();
        services.AddScoped<IAttendanceService, AttendanceManager>();
        services.AddScoped<IRequestLogService, RequestLogManager>();

        return services;
    }
}
