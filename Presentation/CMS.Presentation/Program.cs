using CMS.Application;
using CMS.Persistence;
using Microsoft.Extensions.DependencyInjection;

namespace CMS.Presentation
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.

            ApplicationConfiguration.Initialize();

            var services = new ServiceCollection();

            services.AddLogging();

            services.AddApplicationServices();
            services.AddPersistenceServices();

            services.AddTransient<LoginForm>();
            services.AddTransient<AddStudentForm>();
            services.AddTransient<UpdateStudentForm>();
            services.AddTransient<AddTeacherForm>();
            services.AddTransient<UpdateTeacherForm>();
            services.AddTransient<AddCourseForm>();
            services.AddTransient<UpdateCourseForm>();
            services.AddTransient<AddClassForm>();
            services.AddTransient<UpdateClassForm>();
            services.AddTransient<AddSpecializationForm>();
            services.AddTransient<UpdateSpecializationForm>();
            services.AddTransient<AddExamForm>();
            services.AddTransient<UpdateExamForm>();
            services.AddTransient<AddUserForm>();
            services.AddTransient<UpdateUserForm>();
            services.AddTransient<AddCourseGroupForm>();
            services.AddTransient<UpdateCourseGroupForm>();
            services.AddTransient<ShowCourseStudentsForm>();
            services.AddTransient<ShowCourseGroupStudentsForm>();
            services.AddTransient<RegisterStudentForm>();
            services.AddTransient<TakeAttendanceForm>();
            services.AddTransient<ShowAttendanceForm>();
            services.AddTransient<EnterExamResultsForm>();
            services.AddTransient<ShowExamResultsForm>();
            services.AddTransient<DashboardForm>();

            var serviceProvider = services.BuildServiceProvider();

            System.Windows.Forms.Application.Run(serviceProvider.GetRequiredService<LoginForm>());
        }
    }
}